using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JigsawPuzzle
{
    public partial class frmPlay : Form
    {
        public frmPlay()
        {
            InitializeComponent();

        }

        #region Properties
        private Bitmap ImageFile;
        private string fileName = Application.StartupPath + "\\Resources\\Picture.bmp";
        private List<PictureBox> picture = new List<PictureBox>();
        private int cellSize;
        private Point picLocation;

        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult d = MessageBox.Show("\t Bạn có muốn thoát? \t", "Thoát", MessageBoxButtons.YesNo);
            if (d == DialogResult.No)
                e.Cancel = true;
        }

        private void pnlPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int x = e.Y + pnlPicture.Top - pnlPicture.Height / 2;
                int y = e.X + pnlPicture.Left - pnlPicture.Width / 2;

                if (y < 12) y = 12;
                if (y > 485) y = 485;
                if (x != 446) x = 446;

                pnlPicture.BringToFront();

                pnlPicture.Top = x;
                pnlPicture.Left = y;
            }
        }

        private void pnlPicture_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                OpenFileDialog dlgOpen = new OpenFileDialog();
                dlgOpen.RestoreDirectory = true;
                dlgOpen.Filter = "JPEG Files(*.png)|*.png|JPEG Files(*.jpg)|*.jpg|GIF Files(*.gif)|*.gif|All Files|*.*";
                dlgOpen.FilterIndex = 1;
                if (dlgOpen.ShowDialog() == DialogResult.OK)
                {
                    fileName = dlgOpen.FileName;
                    //cắt ảnh cho vừa đủ để xử lý
                    cutPicture();
                    
                }
            }
        }

        private void cutPicture ()
        {
            if (!System.IO.File.Exists(fileName))
            {
                MessageBox.Show("Không tìm thấy file \n" + fileName);
                return;
            }
            try
            {
                //cắt ảnh thành hình vuông
                Bitmap bmp = new Bitmap(fileName);

                float minSize;
                float width, height;

                if (bmp.Size.Width < bmp.Size.Height)
                    minSize = bmp.Size.Width;
                else
                    minSize = bmp.Size.Height;

                width = bmp.Size.Width;
                height = bmp.Size.Height;

                float heso = 350 / minSize;
                if (heso > 0)
                {
                    width *= heso;
                    height *= heso;
                }

                int imageSize;
                ImageFile = new Bitmap(bmp, new Size((int)width, (int)height));
                
                if (ImageFile.Width < ImageFile.Height)
                    imageSize = ImageFile.Width;
                else
                    imageSize = ImageFile.Height;
                imageSize -= imageSize % 4;
                cellSize = imageSize / 4;

                //fix ảnh cho thành hình vuông
                //ImageFile = new Bitmap(bmp, new Size((int)imageSize, (int)imageSize));
                
                //cắt ảnh thành hình vuông
                
                Rectangle imageRect = new Rectangle(0, 0, imageSize, imageSize);
                ImageFile = ImageFile.Clone(imageRect, PixelFormat.DontCare);

                pnlPicture.BackgroundImage = ImageFile;

                //cắt ảnh thành từng mảnh
                int cellIndex = 0;
                int boxSize = 420 / 4;

                //xóa picturebox đã lưu trước vào panel
                if(picture.Count != 0)
                {
                    for (int i = 0; i < 4 * 4; i++)
                        pnlMain.Controls.Remove(picture[i]);
                    picture.RemoveRange(0, 4 * 4);
                    pnlPlay.Controls.Clear();
                    pnlPlay.Invalidate();
                }
                picture.Clear();

                //lưu các picturebox vào panel
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        try
                        {   
                            picture.Add(new PictureBox());
                            imageRect = new Rectangle(i * cellSize, j * cellSize, cellSize, cellSize);
                            picture[cellIndex].BackgroundImage = null;
                            picture[cellIndex].BackgroundImage = ImageFile.Clone(imageRect, PixelFormat.DontCare);
                            picture[cellIndex].Location = new Point(493 + i * (boxSize), 12 + j * (boxSize));
                            picture[cellIndex].Size = new Size(boxSize, boxSize);
                            picture[cellIndex].Tag = cellIndex.ToString();
                            picture[cellIndex].BackgroundImageLayout = ImageLayout.Stretch;
                            pnlMain.Controls.Add(picture[cellIndex]);
                            picture[cellIndex].BringToFront();
                            picture[cellIndex].MouseMove += FrmPlay_MouseMove;
                            picture[cellIndex].MouseUp += FrmPlay_MouseUp;
                            picture[cellIndex].MouseDown += FrmPlay_MouseDown;
                            cellIndex++;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void FrmPlay_MouseDown(object sender, MouseEventArgs e)
        {
            //lưa vị trí của pic
            PictureBox pic = (PictureBox)sender;
            picLocation = pic.Location;
            pic.BringToFront();
        }

        private void FrmPlay_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            int BoxSize = 420 / 4;
            int col = pic.Location.X / BoxSize;
            int row = pic.Location.Y / BoxSize;

            if (col >= 4 || row >= 4)
                return;

            Control ctl = pnlMain.GetChildAtPoint(new Point(col * BoxSize + 12, row * BoxSize + 12));
            // Nếu đã có một khung ảnh tại ô này
            // thì chuyển vị trí của khung ảnh này về vị trí của khung ảnh vừa drop
            if (ctl != null && ctl is PictureBox)
            {
                ctl.Location = picLocation;
            }

            pic.Location = new Point(col * BoxSize + 12, row * BoxSize + 12);
        }

        private void FrmPlay_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pic.BringToFront();
                int x = e.Y + pic.Top - pic.Height / 2;
                int y = e.X + pic.Left - pic.Width / 2;
                pic.Top = x;
                pic.Left = y;
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            cutPicture(); 
        }
    }
}
