namespace SerializalizationApplication
{
	partial class DataContractForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.CreateAndSerializePerson2Button = new System.Windows.Forms.Button();
			this.DeserializePerson1AndSerializeAgainButton = new System.Windows.Forms.Button();
			this.DeserializePerson2Button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// CreateAndSerializePerson2Button
			// 
			this.CreateAndSerializePerson2Button.Location = new System.Drawing.Point(63, 22);
			this.CreateAndSerializePerson2Button.Name = "CreateAndSerializePerson2Button";
			this.CreateAndSerializePerson2Button.Size = new System.Drawing.Size(198, 56);
			this.CreateAndSerializePerson2Button.TabIndex = 2;
			this.CreateAndSerializePerson2Button.Text = "CreateAndSerializePerson2";
			this.CreateAndSerializePerson2Button.UseVisualStyleBackColor = true;
			this.CreateAndSerializePerson2Button.Click += new System.EventHandler(this.CreateAndSerializePerson2Button_Click);
			// 
			// DeserializePerson1AndSerializeAgainButton
			// 
			this.DeserializePerson1AndSerializeAgainButton.Location = new System.Drawing.Point(61, 112);
			this.DeserializePerson1AndSerializeAgainButton.Name = "DeserializePerson1AndSerializeAgainButton";
			this.DeserializePerson1AndSerializeAgainButton.Size = new System.Drawing.Size(200, 56);
			this.DeserializePerson1AndSerializeAgainButton.TabIndex = 3;
			this.DeserializePerson1AndSerializeAgainButton.Text = "DeserializePerson1AndSerializeAgain";
			this.DeserializePerson1AndSerializeAgainButton.UseVisualStyleBackColor = true;
			this.DeserializePerson1AndSerializeAgainButton.Click += new System.EventHandler(this.DeserializePerson1AndSerializeAgainButton_Click);
			// 
			// DeserializePerson2Button
			// 
			this.DeserializePerson2Button.Location = new System.Drawing.Point(61, 205);
			this.DeserializePerson2Button.Name = "DeserializePerson2Button";
			this.DeserializePerson2Button.Size = new System.Drawing.Size(200, 56);
			this.DeserializePerson2Button.TabIndex = 4;
			this.DeserializePerson2Button.Text = "DeserializePerson2";
			this.DeserializePerson2Button.UseVisualStyleBackColor = true;
			this.DeserializePerson2Button.Click += new System.EventHandler(this.DeserializePerson2Button_Click);
			// 
			// DataContractForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.DeserializePerson2Button);
			this.Controls.Add(this.DeserializePerson1AndSerializeAgainButton);
			this.Controls.Add(this.CreateAndSerializePerson2Button);
			this.Name = "DataContractForm";
			this.Text = "DataContractForm";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CreateAndSerializePerson2Button;
		private System.Windows.Forms.Button DeserializePerson1AndSerializeAgainButton;
		private System.Windows.Forms.Button DeserializePerson2Button;
	}
}