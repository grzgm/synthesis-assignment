namespace WinFormsApp
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpItems = new System.Windows.Forms.TabPage();
            this.gbItemCreator = new System.Windows.Forms.GroupBox();
            this.cbSubCategoryCreator = new System.Windows.Forms.ComboBox();
            this.cbCategoryCreator = new System.Windows.Forms.ComboBox();
            this.cbAvailableCreator = new System.Windows.Forms.CheckBox();
            this.lbAvailableCreator = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbNameCreator = new System.Windows.Forms.Label();
            this.btnItemCreate = new System.Windows.Forms.Button();
            this.lbUnitTypeCreator = new System.Windows.Forms.Label();
            this.tbUnitTypeCreator = new System.Windows.Forms.TextBox();
            this.tbNameCreator = new System.Windows.Forms.TextBox();
            this.tbPriceCreator = new System.Windows.Forms.TextBox();
            this.gbItemDeatils = new System.Windows.Forms.GroupBox();
            this.cbSubCategoryDetails = new System.Windows.Forms.ComboBox();
            this.lbAvailableDetails = new System.Windows.Forms.Label();
            this.cbCategoryDetails = new System.Windows.Forms.ComboBox();
            this.btnItemDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnItemUpdate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.lbNameDetails = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.tbAvailableDetails = new System.Windows.Forms.TextBox();
            this.tbNameDetails = new System.Windows.Forms.TextBox();
            this.tbPriceDetails = new System.Windows.Forms.TextBox();
            this.gbItemSearch = new System.Windows.Forms.GroupBox();
            this.cbSubCategorySearch = new System.Windows.Forms.ComboBox();
            this.lbAvailableSearch = new System.Windows.Forms.Label();
            this.cbCategorySearch = new System.Windows.Forms.ComboBox();
            this.tbAvailableSearch = new System.Windows.Forms.TextBox();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.lvItemSearch = new System.Windows.Forms.ListView();
            this.lbPriceSearch = new System.Windows.Forms.Label();
            this.tbPriceSearch = new System.Windows.Forms.TextBox();
            this.lbSubCategorySearch = new System.Windows.Forms.Label();
            this.lbCategorySearch = new System.Windows.Forms.Label();
            this.lbNameSearch = new System.Windows.Forms.Label();
            this.tbNameSearch = new System.Windows.Forms.TextBox();
            this.tpOrders = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tpItems.SuspendLayout();
            this.gbItemCreator.SuspendLayout();
            this.gbItemDeatils.SuspendLayout();
            this.gbItemSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpItems);
            this.tabControl.Controls.Add(this.tpOrders);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1898, 1024);
            this.tabControl.TabIndex = 0;
            // 
            // tpItems
            // 
            this.tpItems.Controls.Add(this.gbItemCreator);
            this.tpItems.Controls.Add(this.gbItemDeatils);
            this.tpItems.Controls.Add(this.gbItemSearch);
            this.tpItems.Location = new System.Drawing.Point(4, 34);
            this.tpItems.Name = "tpItems";
            this.tpItems.Padding = new System.Windows.Forms.Padding(3);
            this.tpItems.Size = new System.Drawing.Size(1890, 986);
            this.tpItems.TabIndex = 0;
            this.tpItems.Text = "Items";
            this.tpItems.UseVisualStyleBackColor = true;
            // 
            // gbItemCreator
            // 
            this.gbItemCreator.Controls.Add(this.cbSubCategoryCreator);
            this.gbItemCreator.Controls.Add(this.cbCategoryCreator);
            this.gbItemCreator.Controls.Add(this.cbAvailableCreator);
            this.gbItemCreator.Controls.Add(this.lbAvailableCreator);
            this.gbItemCreator.Controls.Add(this.label6);
            this.gbItemCreator.Controls.Add(this.label7);
            this.gbItemCreator.Controls.Add(this.label8);
            this.gbItemCreator.Controls.Add(this.lbNameCreator);
            this.gbItemCreator.Controls.Add(this.btnItemCreate);
            this.gbItemCreator.Controls.Add(this.lbUnitTypeCreator);
            this.gbItemCreator.Controls.Add(this.tbUnitTypeCreator);
            this.gbItemCreator.Controls.Add(this.tbNameCreator);
            this.gbItemCreator.Controls.Add(this.tbPriceCreator);
            this.gbItemCreator.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbItemCreator.Location = new System.Drawing.Point(1262, 3);
            this.gbItemCreator.Name = "gbItemCreator";
            this.gbItemCreator.Size = new System.Drawing.Size(625, 980);
            this.gbItemCreator.TabIndex = 2;
            this.gbItemCreator.TabStop = false;
            this.gbItemCreator.Text = "Item Creator";
            // 
            // cbSubCategoryCreator
            // 
            this.cbSubCategoryCreator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubCategoryCreator.FormattingEnabled = true;
            this.cbSubCategoryCreator.Location = new System.Drawing.Point(264, 104);
            this.cbSubCategoryCreator.Name = "cbSubCategoryCreator";
            this.cbSubCategoryCreator.Size = new System.Drawing.Size(338, 33);
            this.cbSubCategoryCreator.TabIndex = 47;
            // 
            // cbCategoryCreator
            // 
            this.cbCategoryCreator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoryCreator.FormattingEnabled = true;
            this.cbCategoryCreator.Location = new System.Drawing.Point(264, 67);
            this.cbCategoryCreator.Name = "cbCategoryCreator";
            this.cbCategoryCreator.Size = new System.Drawing.Size(338, 33);
            this.cbCategoryCreator.TabIndex = 16;
            this.cbCategoryCreator.SelectedIndexChanged += new System.EventHandler(this.cbCategoryCreator_SelectedIndexChanged);
            // 
            // cbAvailableCreator
            // 
            this.cbAvailableCreator.AutoSize = true;
            this.cbAvailableCreator.Checked = true;
            this.cbAvailableCreator.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAvailableCreator.Location = new System.Drawing.Point(264, 178);
            this.cbAvailableCreator.Name = "cbAvailableCreator";
            this.cbAvailableCreator.Size = new System.Drawing.Size(63, 29);
            this.cbAvailableCreator.TabIndex = 46;
            this.cbAvailableCreator.Text = "Yes";
            this.cbAvailableCreator.UseVisualStyleBackColor = true;
            // 
            // lbAvailableCreator
            // 
            this.lbAvailableCreator.AutoSize = true;
            this.lbAvailableCreator.Location = new System.Drawing.Point(6, 181);
            this.lbAvailableCreator.Name = "lbAvailableCreator";
            this.lbAvailableCreator.Size = new System.Drawing.Size(80, 25);
            this.lbAvailableCreator.TabIndex = 43;
            this.lbAvailableCreator.Text = "available";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 25);
            this.label6.TabIndex = 42;
            this.label6.Text = "price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 25);
            this.label7.TabIndex = 41;
            this.label7.Text = "subcategory";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 25);
            this.label8.TabIndex = 40;
            this.label8.Text = "category";
            // 
            // lbNameCreator
            // 
            this.lbNameCreator.AutoSize = true;
            this.lbNameCreator.Location = new System.Drawing.Point(6, 33);
            this.lbNameCreator.Name = "lbNameCreator";
            this.lbNameCreator.Size = new System.Drawing.Size(56, 25);
            this.lbNameCreator.TabIndex = 39;
            this.lbNameCreator.Text = "name";
            // 
            // btnItemCreate
            // 
            this.btnItemCreate.Location = new System.Drawing.Point(6, 252);
            this.btnItemCreate.Name = "btnItemCreate";
            this.btnItemCreate.Size = new System.Drawing.Size(596, 34);
            this.btnItemCreate.TabIndex = 28;
            this.btnItemCreate.Text = "Create";
            this.btnItemCreate.UseVisualStyleBackColor = true;
            this.btnItemCreate.Click += new System.EventHandler(this.btnItemCreate_Click);
            // 
            // lbUnitTypeCreator
            // 
            this.lbUnitTypeCreator.AutoSize = true;
            this.lbUnitTypeCreator.Location = new System.Drawing.Point(6, 218);
            this.lbUnitTypeCreator.Name = "lbUnitTypeCreator";
            this.lbUnitTypeCreator.Size = new System.Drawing.Size(79, 25);
            this.lbUnitTypeCreator.TabIndex = 38;
            this.lbUnitTypeCreator.Text = "unitType";
            // 
            // tbUnitTypeCreator
            // 
            this.tbUnitTypeCreator.Location = new System.Drawing.Point(264, 215);
            this.tbUnitTypeCreator.Name = "tbUnitTypeCreator";
            this.tbUnitTypeCreator.Size = new System.Drawing.Size(338, 31);
            this.tbUnitTypeCreator.TabIndex = 37;
            // 
            // tbNameCreator
            // 
            this.tbNameCreator.Location = new System.Drawing.Point(264, 30);
            this.tbNameCreator.Name = "tbNameCreator";
            this.tbNameCreator.Size = new System.Drawing.Size(338, 31);
            this.tbNameCreator.TabIndex = 27;
            // 
            // tbPriceCreator
            // 
            this.tbPriceCreator.Location = new System.Drawing.Point(264, 141);
            this.tbPriceCreator.Name = "tbPriceCreator";
            this.tbPriceCreator.Size = new System.Drawing.Size(338, 31);
            this.tbPriceCreator.TabIndex = 33;
            // 
            // gbItemDeatils
            // 
            this.gbItemDeatils.Controls.Add(this.cbSubCategoryDetails);
            this.gbItemDeatils.Controls.Add(this.lbAvailableDetails);
            this.gbItemDeatils.Controls.Add(this.cbCategoryDetails);
            this.gbItemDeatils.Controls.Add(this.btnItemDelete);
            this.gbItemDeatils.Controls.Add(this.label2);
            this.gbItemDeatils.Controls.Add(this.btnItemUpdate);
            this.gbItemDeatils.Controls.Add(this.label3);
            this.gbItemDeatils.Controls.Add(this.label11);
            this.gbItemDeatils.Controls.Add(this.label4);
            this.gbItemDeatils.Controls.Add(this.textBox11);
            this.gbItemDeatils.Controls.Add(this.lbNameDetails);
            this.gbItemDeatils.Controls.Add(this.label10);
            this.gbItemDeatils.Controls.Add(this.textBox10);
            this.gbItemDeatils.Controls.Add(this.tbAvailableDetails);
            this.gbItemDeatils.Controls.Add(this.tbNameDetails);
            this.gbItemDeatils.Controls.Add(this.tbPriceDetails);
            this.gbItemDeatils.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbItemDeatils.Location = new System.Drawing.Point(618, 3);
            this.gbItemDeatils.Name = "gbItemDeatils";
            this.gbItemDeatils.Size = new System.Drawing.Size(1269, 980);
            this.gbItemDeatils.TabIndex = 1;
            this.gbItemDeatils.TabStop = false;
            this.gbItemDeatils.Text = "Item Details";
            // 
            // cbSubCategoryDetails
            // 
            this.cbSubCategoryDetails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubCategoryDetails.FormattingEnabled = true;
            this.cbSubCategoryDetails.Location = new System.Drawing.Point(300, 104);
            this.cbSubCategoryDetails.Name = "cbSubCategoryDetails";
            this.cbSubCategoryDetails.Size = new System.Drawing.Size(338, 33);
            this.cbSubCategoryDetails.TabIndex = 49;
            // 
            // lbAvailableDetails
            // 
            this.lbAvailableDetails.AutoSize = true;
            this.lbAvailableDetails.Location = new System.Drawing.Point(42, 181);
            this.lbAvailableDetails.Name = "lbAvailableDetails";
            this.lbAvailableDetails.Size = new System.Drawing.Size(80, 25);
            this.lbAvailableDetails.TabIndex = 20;
            this.lbAvailableDetails.Text = "available";
            // 
            // cbCategoryDetails
            // 
            this.cbCategoryDetails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoryDetails.FormattingEnabled = true;
            this.cbCategoryDetails.Location = new System.Drawing.Point(300, 67);
            this.cbCategoryDetails.Name = "cbCategoryDetails";
            this.cbCategoryDetails.Size = new System.Drawing.Size(338, 33);
            this.cbCategoryDetails.TabIndex = 48;
            this.cbCategoryDetails.SelectedIndexChanged += new System.EventHandler(this.cbCategoryDetails_SelectedIndexChanged);
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.Location = new System.Drawing.Point(42, 329);
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.Size = new System.Drawing.Size(596, 34);
            this.btnItemDelete.TabIndex = 27;
            this.btnItemDelete.Text = "Delete";
            this.btnItemDelete.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 25);
            this.label2.TabIndex = 19;
            this.label2.Text = "price";
            // 
            // btnItemUpdate
            // 
            this.btnItemUpdate.Location = new System.Drawing.Point(42, 289);
            this.btnItemUpdate.Name = "btnItemUpdate";
            this.btnItemUpdate.Size = new System.Drawing.Size(596, 34);
            this.btnItemUpdate.TabIndex = 14;
            this.btnItemUpdate.Text = "Update";
            this.btnItemUpdate.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = "subcategory";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(42, 255);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 25);
            this.label11.TabIndex = 26;
            this.label11.Text = "label11";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 25);
            this.label4.TabIndex = 17;
            this.label4.Text = "category";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(300, 252);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(338, 31);
            this.textBox11.TabIndex = 25;
            // 
            // lbNameDetails
            // 
            this.lbNameDetails.AutoSize = true;
            this.lbNameDetails.Location = new System.Drawing.Point(42, 33);
            this.lbNameDetails.Name = "lbNameDetails";
            this.lbNameDetails.Size = new System.Drawing.Size(56, 25);
            this.lbNameDetails.TabIndex = 16;
            this.lbNameDetails.Text = "name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(42, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 25);
            this.label10.TabIndex = 24;
            this.label10.Text = "label10";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(300, 215);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(338, 31);
            this.textBox10.TabIndex = 23;
            // 
            // tbAvailableDetails
            // 
            this.tbAvailableDetails.Location = new System.Drawing.Point(300, 178);
            this.tbAvailableDetails.Name = "tbAvailableDetails";
            this.tbAvailableDetails.Size = new System.Drawing.Size(338, 31);
            this.tbAvailableDetails.TabIndex = 21;
            // 
            // tbNameDetails
            // 
            this.tbNameDetails.Location = new System.Drawing.Point(300, 30);
            this.tbNameDetails.Name = "tbNameDetails";
            this.tbNameDetails.Size = new System.Drawing.Size(338, 31);
            this.tbNameDetails.TabIndex = 13;
            // 
            // tbPriceDetails
            // 
            this.tbPriceDetails.Location = new System.Drawing.Point(300, 141);
            this.tbPriceDetails.Name = "tbPriceDetails";
            this.tbPriceDetails.Size = new System.Drawing.Size(338, 31);
            this.tbPriceDetails.TabIndex = 19;
            // 
            // gbItemSearch
            // 
            this.gbItemSearch.Controls.Add(this.cbSubCategorySearch);
            this.gbItemSearch.Controls.Add(this.lbAvailableSearch);
            this.gbItemSearch.Controls.Add(this.cbCategorySearch);
            this.gbItemSearch.Controls.Add(this.tbAvailableSearch);
            this.gbItemSearch.Controls.Add(this.btnItemSearch);
            this.gbItemSearch.Controls.Add(this.lvItemSearch);
            this.gbItemSearch.Controls.Add(this.lbPriceSearch);
            this.gbItemSearch.Controls.Add(this.tbPriceSearch);
            this.gbItemSearch.Controls.Add(this.lbSubCategorySearch);
            this.gbItemSearch.Controls.Add(this.lbCategorySearch);
            this.gbItemSearch.Controls.Add(this.lbNameSearch);
            this.gbItemSearch.Controls.Add(this.tbNameSearch);
            this.gbItemSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbItemSearch.Location = new System.Drawing.Point(3, 3);
            this.gbItemSearch.Name = "gbItemSearch";
            this.gbItemSearch.Size = new System.Drawing.Size(615, 980);
            this.gbItemSearch.TabIndex = 0;
            this.gbItemSearch.TabStop = false;
            this.gbItemSearch.Text = "Item Search";
            // 
            // cbSubCategorySearch
            // 
            this.cbSubCategorySearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubCategorySearch.FormattingEnabled = true;
            this.cbSubCategorySearch.Location = new System.Drawing.Point(271, 104);
            this.cbSubCategorySearch.Name = "cbSubCategorySearch";
            this.cbSubCategorySearch.Size = new System.Drawing.Size(338, 33);
            this.cbSubCategorySearch.TabIndex = 51;
            // 
            // lbAvailableSearch
            // 
            this.lbAvailableSearch.AutoSize = true;
            this.lbAvailableSearch.Location = new System.Drawing.Point(13, 181);
            this.lbAvailableSearch.Name = "lbAvailableSearch";
            this.lbAvailableSearch.Size = new System.Drawing.Size(80, 25);
            this.lbAvailableSearch.TabIndex = 15;
            this.lbAvailableSearch.Text = "available";
            // 
            // cbCategorySearch
            // 
            this.cbCategorySearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategorySearch.FormattingEnabled = true;
            this.cbCategorySearch.Location = new System.Drawing.Point(271, 67);
            this.cbCategorySearch.Name = "cbCategorySearch";
            this.cbCategorySearch.Size = new System.Drawing.Size(338, 33);
            this.cbCategorySearch.TabIndex = 50;
            this.cbCategorySearch.SelectedIndexChanged += new System.EventHandler(this.cbCategorySearch_SelectedIndexChanged);
            // 
            // tbAvailableSearch
            // 
            this.tbAvailableSearch.Location = new System.Drawing.Point(271, 178);
            this.tbAvailableSearch.Name = "tbAvailableSearch";
            this.tbAvailableSearch.Size = new System.Drawing.Size(338, 31);
            this.tbAvailableSearch.TabIndex = 14;
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Location = new System.Drawing.Point(13, 215);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(596, 34);
            this.btnItemSearch.TabIndex = 13;
            this.btnItemSearch.Text = "Search";
            this.btnItemSearch.UseVisualStyleBackColor = true;
            // 
            // lvItemSearch
            // 
            this.lvItemSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvItemSearch.Location = new System.Drawing.Point(3, 255);
            this.lvItemSearch.Name = "lvItemSearch";
            this.lvItemSearch.Size = new System.Drawing.Size(609, 722);
            this.lvItemSearch.TabIndex = 12;
            this.lvItemSearch.UseCompatibleStateImageBehavior = false;
            // 
            // lbPriceSearch
            // 
            this.lbPriceSearch.AutoSize = true;
            this.lbPriceSearch.Location = new System.Drawing.Point(13, 144);
            this.lbPriceSearch.Name = "lbPriceSearch";
            this.lbPriceSearch.Size = new System.Drawing.Size(50, 25);
            this.lbPriceSearch.TabIndex = 11;
            this.lbPriceSearch.Text = "price";
            // 
            // tbPriceSearch
            // 
            this.tbPriceSearch.Location = new System.Drawing.Point(271, 141);
            this.tbPriceSearch.Name = "tbPriceSearch";
            this.tbPriceSearch.Size = new System.Drawing.Size(338, 31);
            this.tbPriceSearch.TabIndex = 10;
            // 
            // lbSubCategorySearch
            // 
            this.lbSubCategorySearch.AutoSize = true;
            this.lbSubCategorySearch.Location = new System.Drawing.Point(13, 107);
            this.lbSubCategorySearch.Name = "lbSubCategorySearch";
            this.lbSubCategorySearch.Size = new System.Drawing.Size(110, 25);
            this.lbSubCategorySearch.TabIndex = 9;
            this.lbSubCategorySearch.Text = "subcategory";
            // 
            // lbCategorySearch
            // 
            this.lbCategorySearch.AutoSize = true;
            this.lbCategorySearch.Location = new System.Drawing.Point(13, 70);
            this.lbCategorySearch.Name = "lbCategorySearch";
            this.lbCategorySearch.Size = new System.Drawing.Size(81, 25);
            this.lbCategorySearch.TabIndex = 7;
            this.lbCategorySearch.Text = "category";
            // 
            // lbNameSearch
            // 
            this.lbNameSearch.AutoSize = true;
            this.lbNameSearch.Location = new System.Drawing.Point(13, 33);
            this.lbNameSearch.Name = "lbNameSearch";
            this.lbNameSearch.Size = new System.Drawing.Size(56, 25);
            this.lbNameSearch.TabIndex = 5;
            this.lbNameSearch.Text = "name";
            // 
            // tbNameSearch
            // 
            this.tbNameSearch.Location = new System.Drawing.Point(271, 30);
            this.tbNameSearch.Name = "tbNameSearch";
            this.tbNameSearch.Size = new System.Drawing.Size(338, 31);
            this.tbNameSearch.TabIndex = 0;
            // 
            // tpOrders
            // 
            this.tpOrders.Location = new System.Drawing.Point(4, 34);
            this.tpOrders.Name = "tpOrders";
            this.tpOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tpOrders.Size = new System.Drawing.Size(1890, 986);
            this.tpOrders.TabIndex = 1;
            this.tpOrders.Text = "Orders";
            this.tpOrders.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.tabControl);
            this.Name = "Main";
            this.Text = "RobertHeijn B.V.";
            this.tabControl.ResumeLayout(false);
            this.tpItems.ResumeLayout(false);
            this.gbItemCreator.ResumeLayout(false);
            this.gbItemCreator.PerformLayout();
            this.gbItemDeatils.ResumeLayout(false);
            this.gbItemDeatils.PerformLayout();
            this.gbItemSearch.ResumeLayout(false);
            this.gbItemSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl;
        private TabPage tpItems;
        private TabPage tpOrders;
        private GroupBox gbItemCreator;
        private GroupBox gbItemDeatils;
        private GroupBox gbItemSearch;
        private Label lbNameSearch;
        private TextBox tbNameSearch;
        private Label label11;
        private TextBox textBox11;
        private Label label10;
        private TextBox textBox10;
        private TextBox tbAvailableDetails;
        private TextBox tbNameDetails;
        private TextBox tbPriceDetails;
        private ListView lvItemSearch;
        private Label lbPriceSearch;
        private TextBox tbPriceSearch;
        private Label lbSubCategorySearch;
        private Label lbCategorySearch;
        private Button btnItemCreate;
        private Label lbUnitTypeCreator;
        private TextBox tbUnitTypeCreator;
        private TextBox tbNameCreator;
        private TextBox tbPriceCreator;
        private Button btnItemDelete;
        private Button btnItemUpdate;
        private Button btnItemSearch;
        private Label lbAvailableSearch;
        private TextBox tbAvailableSearch;
        private Label lbAvailableCreator;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lbNameCreator;
        private Label lbAvailableDetails;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lbNameDetails;
        private CheckBox cbAvailableCreator;
        private ComboBox cbSubCategoryCreator;
        private ComboBox cbCategoryCreator;
        private ComboBox cbSubCategoryDetails;
        private ComboBox cbCategoryDetails;
        private ComboBox cbSubCategorySearch;
        private ComboBox cbCategorySearch;
    }
}