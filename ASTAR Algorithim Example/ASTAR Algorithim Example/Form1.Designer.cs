namespace ASTAR_Algorithim_Example
{
    partial class Form1
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
            if (disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            this.btn_v_execute = new System.Windows.Forms.Button();
            this.Simulator = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_v_execute
            // 
            this.btn_v_execute.Location = new System.Drawing.Point(618, 13);
            this.btn_v_execute.Name = "btn_v_execute";
            this.btn_v_execute.Size = new System.Drawing.Size(118, 41);
            this.btn_v_execute.TabIndex = 0;
            this.btn_v_execute.Text = "Execute";
            this.btn_v_execute.UseVisualStyleBackColor = true;
            this.btn_v_execute.Click += new System.EventHandler(this.button1_Click);
            // 
            // Simulator
            // 
            this.Simulator.Tick += new System.EventHandler(this.Simulator_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 596);
            this.Controls.Add(this.btn_v_execute);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_v_execute;
        private System.Windows.Forms.Timer Simulator;
    }
}

