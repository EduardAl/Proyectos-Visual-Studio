using System;
using System.Windows.Forms;
using System.Drawing;

namespace ACOPEDH
{
    class PlaceHolderTextbox : TextBox
    {
        bool isPlaceHolder = true;
        string PlaceHolderText;
        public string PlaceHolder
        {
            get { return PlaceHolderText; }
            set
            {
                PlaceHolderText = value;
                SetPlaceholder();
            }
        }

        public new string Text
        {
            get => isPlaceHolder ? string.Empty : base.Text;
            set => base.Text = value;
        }
        
        private void SetPlaceholder()
        {
            if (string.IsNullOrEmpty(base.Text))
            {
                base.Text = PlaceHolder;
                this.ForeColor = Color.Gray;
                this.Font = new Font(this.Font, FontStyle.Regular);
                isPlaceHolder = true;
            }
        }
        
        private void RemovePlaceHolder()
        {

            if (isPlaceHolder)
            {
                base.Text = "";
                this.ForeColor = System.Drawing.SystemColors.WindowText;
                this.Font = new Font(this.Font, FontStyle.Regular);
                isPlaceHolder = false;
            }
        }
        public PlaceHolderTextbox()
        {
            GotFocus += RemovePlaceHolder;
            LostFocus += SetPlaceholder;
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            SetPlaceholder();
        }

        private void RemovePlaceHolder(object sender, EventArgs e)
        {
            RemovePlaceHolder();
        }
    }
}
