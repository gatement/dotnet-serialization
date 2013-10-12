namespace SerializalizationApplication
{
	partial class DataContractJsonSerializerForm
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
			this.SerializeButton = new System.Windows.Forms.Button();
			this.DeserializeButton = new System.Windows.Forms.Button();
			this.DeserializeToDog2Button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// SerializeButton
			// 
			this.SerializeButton.Location = new System.Drawing.Point(65, 27);
			this.SerializeButton.Name = "SerializeButton";
			this.SerializeButton.Size = new System.Drawing.Size(198, 56);
			this.SerializeButton.TabIndex = 3;
			this.SerializeButton.Text = "Serialize";
			this.SerializeButton.UseVisualStyleBackColor = true;
			this.SerializeButton.Click += new System.EventHandler(this.SerializeButton_Click);
			// 
			// DeserializeButton
			// 
			this.DeserializeButton.Location = new System.Drawing.Point(65, 113);
			this.DeserializeButton.Name = "DeserializeButton";
			this.DeserializeButton.Size = new System.Drawing.Size(198, 56);
			this.DeserializeButton.TabIndex = 4;
			this.DeserializeButton.Text = "Deserialize";
			this.DeserializeButton.UseVisualStyleBackColor = true;
			this.DeserializeButton.Click += new System.EventHandler(this.DeserializeButton_Click);
			// 
			// DeserializeToDog2Button
			// 
			this.DeserializeToDog2Button.Location = new System.Drawing.Point(65, 207);
			this.DeserializeToDog2Button.Name = "DeserializeToDog2Button";
			this.DeserializeToDog2Button.Size = new System.Drawing.Size(198, 56);
			this.DeserializeToDog2Button.TabIndex = 5;
			this.DeserializeToDog2Button.Text = "DeserializeToDog2";
			this.DeserializeToDog2Button.UseVisualStyleBackColor = true;
			this.DeserializeToDog2Button.Click += new System.EventHandler(this.DeserializeToDog2Button_Click);
			// 
			// DataContractJsonSerializerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(345, 324);
			this.Controls.Add(this.DeserializeToDog2Button);
			this.Controls.Add(this.DeserializeButton);
			this.Controls.Add(this.SerializeButton);
			this.Name = "DataContractJsonSerializerForm";
			this.Text = "DataContractJsonSerializerForm";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button SerializeButton;
		private System.Windows.Forms.Button DeserializeButton;
		private System.Windows.Forms.Button DeserializeToDog2Button;
	}
}