﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

using Newtonsoft.Json;

using Sq1.Core.DataTypes;
using Sq1.Core.Execution;

namespace Sq1.Core.Streaming {
	public class StreamingDataSnapshot {
		[JsonIgnore]	StreamingAdapter			streamingAdapter;
		[JsonIgnore]	object						lockLastQuote;
		[JsonProperty]	Dictionary<string, LevelTwoAndLastQuote>	level2andLastQuoteUnboundClone_bySymbol;	// { get; private set; }
		public long Level2RefreshRate;

		[JsonProperty]	public string				SymbolsSubscribedAndReceiving		{ get {
				string ret = "";
				foreach (string symbol in level2andLastQuoteUnboundClone_bySymbol.Keys) {
					if (ret.Length > 0) ret += ",";
					ret += symbol;
					Quote lastClone = this.LastQuoteCloneGetForSymbol(symbol);
					ret += ":";
					if (lastClone == null) {
						ret += "NULL";
					} else {
						ret += lastClone.AbsnoPerSymbol.ToString();
					}
				}
				return ret;
			} }

		StreamingDataSnapshot() {
			level2andLastQuoteUnboundClone_bySymbol = new Dictionary<string, LevelTwoAndLastQuote>();
			lockLastQuote = new object();
		}

		public StreamingDataSnapshot(StreamingAdapter streamingAdapter) : this() {
			if (streamingAdapter == null) {
				string msg = "DESERIALIZATION_ANOMALY DONT_FORGET_TO_INVOKE_InitializeWithStreaming()_AFTER_ALL_DATASOURCES_DESERIALIZED";
				//Assembler.PopupException(msg);
			}
			this.streamingAdapter = streamingAdapter;
		}

		public void InitializeLastQuoteReceived(List<string> symbols) {
			foreach (string symbol in symbols) {
				this.InitializeLastQuoteAndLevelTwoForSymbol(symbol);
			}
		}
		public void InitializeLastQuoteAndLevelTwoForSymbol(string symbol) { lock (this.lockLastQuote) {
			if (this.level2andLastQuoteUnboundClone_bySymbol.ContainsKey(symbol) == false) {
				this.level2andLastQuoteUnboundClone_bySymbol.Add(symbol, new LevelTwoAndLastQuote(symbol));
			}
			Quote prevQuote = this.level2andLastQuoteUnboundClone_bySymbol[symbol].Initialize();
		} }
		public void LastQuoteCloneSetForSymbol(Quote quote) { lock (this.lockLastQuote) {
			string msig = " StreamingDataSnapshot.LastQuoteSetForSymbol(" + quote.ToString() + ")";

			if (quote == null) {
				string msg = "USE_LastQuoteInitialize_INSTEAD_OF_PASSING_NULL_TO_LastQuoteCloneSetForSymbol";
				Assembler.PopupException(msg + msig);
				return;
			}
			if (this.level2andLastQuoteUnboundClone_bySymbol.ContainsKey(quote.Symbol) == false) {
				this.level2andLastQuoteUnboundClone_bySymbol.Add(quote.Symbol, null);
				string msg = "SUBSCRIBER_SHOULD_HAVE_INVOKED_LastQuoteInitialize()__FOLLOW_THIS_LIFECYCLE__ITS_A_RELIGION_NOT_OPEN_FOR_DISCUSSION";
				Assembler.PopupException(msg + msig);
			}

			Quote lastQuote = this.level2andLastQuoteUnboundClone_bySymbol[quote.Symbol].LastQuote;
			if (lastQuote == null) {
				string msg = "RECEIVED_FIRST_QUOTE_EVER_FOR#2 symbol[" + quote.Symbol + "] SKIPPING_LASTQUOTE_ABSNO_CHECK SKIPPING_QUOTE<=LASTQUOTE_NEXT_CHECK";
				//Assembler.PopupException(msg, null, false);
				this.level2andLastQuoteUnboundClone_bySymbol[quote.Symbol].LastQuote = quote;
				return;
			}
			if (lastQuote == quote) {
				string msg = "DONT_PUT_SAME_QUOTE_TWICE";
				Assembler.PopupException(msg + msig);
				return;
			}
			if (lastQuote.AbsnoPerSymbol >= quote.AbsnoPerSymbol) {
				string msg = "DONT_FEED_ME_WITH_OLD_QUOTES (????QuoteQuik #-1/0 AUTOGEN)";
				Assembler.PopupException(msg + msig);
				return;
			}
			this.level2andLastQuoteUnboundClone_bySymbol[quote.Symbol].LastQuote = quote;
		} }
		public Quote LastQuoteCloneGetForSymbol(string Symbol) { lock (this.lockLastQuote) {
				if (this.level2andLastQuoteUnboundClone_bySymbol.ContainsKey(Symbol) == false) return null;
				Quote weirdAttachedToOriginalBarsInsteadOfRegeneratedGrowingCopy = this.level2andLastQuoteUnboundClone_bySymbol[Symbol].LastQuote;
				return weirdAttachedToOriginalBarsInsteadOfRegeneratedGrowingCopy;
			} }
		public LevelTwoHalf LevelTwoAsks_getForSymbol(string Symbol) { lock (this.lockLastQuote) {
				if (this.level2andLastQuoteUnboundClone_bySymbol.ContainsKey(Symbol) == false) return null;
				return this.level2andLastQuoteUnboundClone_bySymbol[Symbol].Asks;
			} }
		public LevelTwoHalf LevelTwoBids_getForSymbol(string Symbol) { lock (this.lockLastQuote) {
				if (this.level2andLastQuoteUnboundClone_bySymbol.ContainsKey(Symbol) == false) return null;
				return this.level2andLastQuoteUnboundClone_bySymbol[Symbol].Bids;
			} }
		public double LastQuoteGetPriceForMarketOrder(string Symbol) {
			Quote lastQuote = this.LastQuoteCloneGetForSymbol(Symbol);
			if (lastQuote == null) return 0;
			if (lastQuote.TradedAt == BidOrAsk.UNKNOWN) {
				string msg = "NEVER_HAPPENED_SO_FAR LAST_QUOTE_MUST_BE_BID_OR_ASK lastQuote.TradeOccuredAt[" + lastQuote.TradedAt + "]=BidOrAsk.UNKNOWN";
				Assembler.PopupException(msg);
				return 0;
			}
			return lastQuote.TradedPrice;
		}

		public double BestBidGetForMarketOrder(string Symbol) {
			double ret = -1;
			Quote lastQuote = this.LastQuoteCloneGetForSymbol(Symbol);
			if (lastQuote == null) {
				string msg = "LAST_TIME_I_HAD_IT_WHEN_Livesimulator_STORED_QUOTES_IN_QuikLivesimStreaming_WHILE_MarketLive_ASKED_QuikStreaming_TO_FILL_ALERT";
				Assembler.PopupException(msg);
				return ret;
			}
			ret = lastQuote.Bid;
			return ret;
		} 
		public double BestAskGetForMarketOrder(string Symbol) {
			double ret = -1;
			Quote lastQuote = this.LastQuoteCloneGetForSymbol(Symbol);
			if (lastQuote == null) {
				string msg = "LAST_TIME_I_HAD_IT_WHEN_Livesimulator_STORED_QUOTES_IN_QuikLivesimStreaming_WHILE_MarketLive_ASKED_QuikStreaming_TO_FILL_ALERT";
				Assembler.PopupException(msg);
				return ret;
			}
			ret = lastQuote.Ask;
			return ret;
		}

		public double BidOrAskFor(string Symbol, PositionLongShort direction) {
			if (direction == PositionLongShort.Unknown) {
				string msg = "BidOrAskFor(" + Symbol + ", " + direction + "): Bid and Ask are wrong to return for [" + direction + "]";
				throw new Exception(msg);
			}
			double price = (direction == PositionLongShort.Long)
				? this.BestBidGetForMarketOrder(Symbol) : this.BestAskGetForMarketOrder(Symbol);
			return price;
		}
		public virtual double GetAlignedBidOrAskForTidalOrCrossMarketFromStreaming(string symbol, Direction direction
				, out OrderSpreadSide oss, bool forceCrossMarket) {
			string msig = " //GetAlignedBidOrAskForTidalOrCrossMarketFromStreaming(" + symbol + ", " + direction + ")";
			double priceLastQuote = this.LastQuoteGetPriceForMarketOrder(symbol);
			if (priceLastQuote == 0) {
				string msg = "QuickCheck ZERO priceLastQuote=" + priceLastQuote + " for Symbol=[" + symbol + "]"
					+ " from streamingAdapter[" + this.streamingAdapter.Name + "].StreamingDataSnapshot";
				Assembler.PopupException(msg);
				//throw new Exception(msg);
			}
			double currentBid = this.BestBidGetForMarketOrder(symbol);
			double currentAsk = this.BestAskGetForMarketOrder(symbol);
			if (currentBid == 0) {
				string msg = "ZERO currentBid=" + currentBid + " for Symbol=[" + symbol + "]"
					+ " while priceLastQuote=[" + priceLastQuote + "]"
					+ " from streamingAdapter[" + this.streamingAdapter.Name + "].StreamingDataSnapshot";
				;
				Assembler.PopupException(msg);
				//throw new Exception(msg);
			}
			if (currentAsk == 0) {
				string msg = "ZERO currentAsk=" + currentAsk + " for Symbol=[" + symbol + "]"
					+ " while priceLastQuote=[" + priceLastQuote + "]"
					+ " from streamingAdapter[" + this.streamingAdapter.Name + "].StreamingDataSnapshot";
				Assembler.PopupException(msg);
				//throw new Exception(msg);
			}

			double price = 0;
			oss = OrderSpreadSide.ERROR;

			SymbolInfo symbolInfo = Assembler.InstanceInitialized.RepositorySymbolInfos.FindSymbolInfo_nullUnsafe(symbol);
			MarketOrderAs spreadSide;
			if (forceCrossMarket) {
				spreadSide = MarketOrderAs.LimitCrossMarket;
			} else {
				spreadSide = (symbolInfo == null) ? MarketOrderAs.LimitCrossMarket : symbolInfo.MarketOrderAs;
			}
			if (spreadSide == MarketOrderAs.ERROR || spreadSide == MarketOrderAs.Unknown) {
				string msg = "CHANGE SymbolInfo[" + symbol + "].LimitCrossMarket; should not be spreadSide[" + spreadSide + "]";
				Assembler.PopupException(msg);
				throw new Exception(msg);
				//return;
			}

			switch (direction) {
				case Direction.Buy:
				case Direction.Cover:
					switch (spreadSide) {
						case MarketOrderAs.LimitTidal:
							oss = OrderSpreadSide.AskTidal;
							price = currentAsk;
							break;
						case MarketOrderAs.LimitCrossMarket:
							oss = OrderSpreadSide.BidCrossed;
							price = currentBid;		// Unknown (Order default) becomes CrossMarket
							break;
						case MarketOrderAs.MarketMinMaxSentToBroker:
							oss = OrderSpreadSide.MaxPrice;
							price = currentAsk;
							break;
						case MarketOrderAs.MarketZeroSentToBroker:
							oss = OrderSpreadSide.MarketPrice;
							price = currentAsk;		// looks like default, must be crossmarket to fill it right now
							break;
						default:
							string msg2 = "no handler for spreadSide[" + spreadSide + "] direction[" + direction + "]";
							throw new Exception(msg2 + msig);
					}
					break;
				case Direction.Short:
				case Direction.Sell:
					switch (spreadSide) {
						case MarketOrderAs.LimitTidal:
							oss = OrderSpreadSide.BidTidal;
							price = currentBid;
							break;
						case MarketOrderAs.LimitCrossMarket:
							oss = OrderSpreadSide.AskCrossed;
							price = currentAsk;		// Unknown (Order default) becomes CrossMarket
							break;
						case MarketOrderAs.MarketMinMaxSentToBroker:
							oss = OrderSpreadSide.MinPrice;
							price = currentBid;		// Unknown (Order default) becomes CrossMarket
							break;
						case MarketOrderAs.MarketZeroSentToBroker:
							oss = OrderSpreadSide.MarketPrice;
							price = currentBid;		// looks like default, must be crossmarket to fill it right now
							break;
						default:
							string msg2 = "no handler for spreadSide[" + spreadSide + "] direction[" + direction + "]";
							throw new Exception(msg2 + msig);
					}
					break;
				default:
					string msg = "no handler for direction[" + direction + "]";
					throw new Exception(msg + msig);
			}

			if (double.IsNaN(price)) {
				string msg = "NEVER_HAPPENED_SO_FAR PRICE_MUST_BE_POSITIVE_NOT_NAN";
				Debugger.Break();
			}
			symbolInfo = Assembler.InstanceInitialized.RepositorySymbolInfos.FindSymbolInfoOrNew(symbol);
			//v2
			price = symbolInfo.AlignAlertToPriceLevelSimplified(price, direction, MarketLimitStop.Market);

			//v1
			#if DEBUG	// REMOVE_ONCE_NEW_ALIGNMENT_MATURES_DECEMBER_15TH_2014
			double price1 = symbolInfo.AlignOrderToPriceLevel(price, direction, MarketLimitStop.Market);
			if (price1 != price) {
				string msg3 = "FIX_DEFINITELY_DIFFERENT_POSTPONE_TILL_ORDER_EXECUTOR_BACK_FOR_QUIK_BROKER";
				Assembler.PopupException(msg3 + msig, null);
			}
			#endif
			
			return price;
		}
		public override string ToString() {
			return "StreamingDataSnapshot_FOR_" + this.streamingAdapter;
		}

	}
}
