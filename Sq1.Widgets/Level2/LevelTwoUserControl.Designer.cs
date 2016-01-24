﻿namespace Sq1.Widgets.Level2 {
	partial class LevelTwoUserControl {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblDomTitle = new System.Windows.Forms.Label();
			this.olvcLevelTwo = new BrightIdeasSoftware.ObjectListView();
			this.olvWeirdBehaviourShiftedToFirstColumnFake = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvAskCumulative = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvAsk = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvBid = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvBidCumulative = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.olvcLevelTwo)).BeginInit();
			this.SuspendLayout();
			// 
			// UserControlInner
			// 
			this.UserControlInner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.UserControlInner.Padding = new System.Windows.Forms.Padding(0, 18, 0, 0);
			this.UserControlInner.Size = new System.Drawing.Size(206, 402);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lblDomTitle);
			this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.panel1.ForeColor = System.Drawing.SystemColors.Window;
			this.panel1.Location = new System.Drawing.Point(4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(206, 19);
			this.panel1.TabIndex = 1;
			// 
			// lblDomTitle
			// 
			this.lblDomTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDomTitle.AutoSize = true;
			this.lblDomTitle.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDomTitle.Location = new System.Drawing.Point(3, 2);
			this.lblDomTitle.Name = "lblDomTitle";
			this.lblDomTitle.Size = new System.Drawing.Size(232, 13);
			this.lblDomTitle.TabIndex = 0;
			this.lblDomTitle.Text = "SQ1-RIM3-dom [232323] RECEIVING#2";
			// 
			// olvcLevelTwo
			// 
			this.olvcLevelTwo.AllColumns.Add(this.olvWeirdBehaviourShiftedToFirstColumnFake);
			this.olvcLevelTwo.AllColumns.Add(this.olvAskCumulative);
			this.olvcLevelTwo.AllColumns.Add(this.olvAsk);
			this.olvcLevelTwo.AllColumns.Add(this.olvPrice);
			this.olvcLevelTwo.AllColumns.Add(this.olvBid);
			this.olvcLevelTwo.AllColumns.Add(this.olvBidCumulative);
			this.olvcLevelTwo.AllowColumnReorder = true;
			this.olvcLevelTwo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.olvcLevelTwo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.olvcLevelTwo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvWeirdBehaviourShiftedToFirstColumnFake,
            this.olvAsk,
            this.olvPrice,
            this.olvBid});
			this.olvcLevelTwo.Cursor = System.Windows.Forms.Cursors.Default;
			this.olvcLevelTwo.EmptyListMsg = "No Level2 Received Yet";
			this.olvcLevelTwo.HideSelection = false;
			this.olvcLevelTwo.Location = new System.Drawing.Point(4, 72);
			this.olvcLevelTwo.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
			this.olvcLevelTwo.Name = "olvcLevelTwo";
			this.olvcLevelTwo.ShowCommandMenuOnRightClick = true;
			this.olvcLevelTwo.ShowGroups = false;
			this.olvcLevelTwo.Size = new System.Drawing.Size(206, 288);
			this.olvcLevelTwo.TabIndex = 2;
			this.olvcLevelTwo.TintSortColumn = true;
			this.olvcLevelTwo.UseCompatibleStateImageBehavior = false;
			this.olvcLevelTwo.UseFilterIndicator = true;
			this.olvcLevelTwo.UseHotItem = true;
			this.olvcLevelTwo.UseTranslucentHotItem = true;
			this.olvcLevelTwo.UseTranslucentSelection = true;
			this.olvcLevelTwo.View = System.Windows.Forms.View.Details;
			// 
			// olvWeirdBehaviourShiftedToFirstColumnFake
			// 
			this.olvWeirdBehaviourShiftedToFirstColumnFake.IsVisible = false;
			this.olvWeirdBehaviourShiftedToFirstColumnFake.Text = "_WeirdBehaviourShiftedToFirstColumnFake";
			this.olvWeirdBehaviourShiftedToFirstColumnFake.Width = 1;
			// 
			// olvAskCumulative
			// 
			this.olvAskCumulative.DisplayIndex = 0;
			this.olvAskCumulative.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.olvAskCumulative.IsVisible = false;
			this.olvAskCumulative.Text = "AskCumulative";
			this.olvAskCumulative.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// olvAsk
			// 
			this.olvAsk.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.olvAsk.Text = "AskVolume";
			this.olvAsk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// olvPrice
			// 
			this.olvPrice.FillsFreeSpace = true;
			this.olvPrice.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.olvPrice.IsEditable = false;
			this.olvPrice.Text = "Price";
			this.olvPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.olvPrice.Width = 100;
			// 
			// olvBid
			// 
			this.olvBid.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.olvBid.Text = "BidVolume";
			this.olvBid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// olvBidCumulative
			// 
			this.olvBidCumulative.DisplayIndex = 4;
			this.olvBidCumulative.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.olvBidCumulative.IsVisible = false;
			this.olvBidCumulative.Text = "BidCumulative";
			this.olvBidCumulative.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// QuikStreamingMonitorDomUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.olvcLevelTwo);
			this.Controls.Add(this.panel1);
			this.Name = "QuikStreamingMonitorDomUserControl";
			this.Size = new System.Drawing.Size(214, 410);
			this.Controls.SetChildIndex(this.UserControlInner, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.olvcLevelTwo, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.olvcLevelTwo)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblDomTitle;
		private BrightIdeasSoftware.OLVColumn olvAsk;
		private BrightIdeasSoftware.OLVColumn olvPrice;
		private BrightIdeasSoftware.OLVColumn olvBid;
		private BrightIdeasSoftware.ObjectListView olvcLevelTwo;
		private BrightIdeasSoftware.OLVColumn olvAskCumulative;
		private BrightIdeasSoftware.OLVColumn olvBidCumulative;
		private BrightIdeasSoftware.OLVColumn olvWeirdBehaviourShiftedToFirstColumnFake;
	}
}
