using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;
using VenusBiller.Properties;

namespace VenusBiller
{

    #region CellModel

    public class GridPushButtonImageCellModel : GridPushButtonCellModel
    {
        protected GridPushButtonImageCellModel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public GridPushButtonImageCellModel(GridModel grid)
            : base(grid)
        {
        }

        public override GridCellRendererBase CreateRenderer(GridControlBase control)
        {
            return new GridPushButtonImageCellRenderer(control, this);
        }
    }

    #endregion

    #region CellRenderer

    public class GridPushButtonImageCellRenderer : GridPushButtonCellRenderer
    {
        private ImageCellButton pushButton;

        public GridPushButtonImageCellRenderer(GridControlBase grid, GridPushButtonImageCellModel cellModel)
            : base(grid, cellModel)
        {
            base.RemoveButton(GetButton(0));
            AddButton(pushButton = new ImageCellButton(this));
        }
    }

    #endregion

    #region ImageCellButton

    public class ImageCellButton : GridCellButton
    {
        private static readonly GridIconPaint IconPainter;

        static ImageCellButton()
        {
            IconPainter = new GridIconPaint("ImagePushButton.", typeof (ImageCellButton).Assembly);
        }


        public ImageCellButton(GridPushButtonCellRenderer control)
            : base(control)
        {
        }


        public override void Draw(Graphics g, int rowIndex, int colIndex, bool bActive, GridStyleInfo style)
        {
            base.Draw(g, rowIndex, colIndex, bActive, style);

            // draw the button
            bool hovering = IsHovering(rowIndex, colIndex);
            bool mouseDown = IsMouseDown(rowIndex, colIndex);
            bool disabled = !style.Clickable;

            var buttonState = ButtonState.Normal;
            if (disabled)
                buttonState |= ButtonState.Inactive | ButtonState.Flat;

            else if (!hovering && !mouseDown)
                buttonState |= ButtonState.Flat;

            Point ptOffset = Point.Empty;
            if (mouseDown)
            {
                ptOffset = new Point(1, 1);
                buttonState |= ButtonState.Pushed;
            }

            DrawButton(g, Bounds, buttonState, style);
            Image img = Resources.delete24;
            var bmp = img as Bitmap;
            Rectangle r = IconPainter.PaintIcon(g, Bounds, ptOffset, bmp, Color.Black);
        }
    }

    #endregion
}