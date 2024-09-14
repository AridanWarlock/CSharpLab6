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
            Âîëê_ËPictureBox.Controls.Add(Êîğçèíà_ËÂPictureBox);

            //Êîğçèíà_ËÂPictureBox.Parent = Âîëê_ËPictureBox;

            //Âîëê_ËPictureBox.Parent = this;
            //Âîëê_ËPictureBox.SetStyle(ControlStyles.UserPaint);
            //panel1.Controls.Add(transPanel1);

            panel2.Controls.Add(Âîëê_ËPictureBox);
            panel2.Controls.Add(Êîğçèíà_ËÂPictureBox);
        }

        private void Êîëîêîëü÷èê_ÍPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
