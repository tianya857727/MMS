namespace MMS
{
    partial class UnitCellState
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.HgalaodState = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.HgalaodState});
            this.shapeContainer1.Size = new System.Drawing.Size(743, 40);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // HgalaodState
            // 
            this.HgalaodState.BackColor = System.Drawing.Color.Black;
            this.HgalaodState.BorderColor = System.Drawing.Color.White;
            this.HgalaodState.FillColor = System.Drawing.Color.Red;
            this.HgalaodState.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.HgalaodState.Location = new System.Drawing.Point(30, 12);
            this.HgalaodState.Name = "HgalaodState";
            this.HgalaodState.Size = new System.Drawing.Size(28, 16);
            // 
            // UnitCellState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.shapeContainer1);
            this.Name = "UnitCellState";
            this.Size = new System.Drawing.Size(743, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape HgalaodState;

    }
}
