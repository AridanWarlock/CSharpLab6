namespace CSharpLab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ����_�PictureBox.Controls.Add(�������_��PictureBox);

            //�������_��PictureBox.Parent = ����_�PictureBox;

            //����_�PictureBox.Parent = this;
            //����_�PictureBox.SetStyle(ControlStyles.UserPaint);
            //panel1.Controls.Add(transPanel1);

            panel2.Controls.Add(����_�PictureBox);
            panel2.Controls.Add(�������_��PictureBox);
        }

        private void �����������_�PictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
