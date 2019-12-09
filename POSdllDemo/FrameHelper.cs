﻿using System;
using System.Windows.Forms;

namespace GprinterDEMO
{

    class FrameHelper
    {

        public static void AutoSizeColumn(DataGridView DGVFiles)
        {
            int width = 0;
            //使列自适应宽度
            //对于每一列都调整
            for (int i = 0; i < DGVFiles.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                DGVFiles.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                //记录整个的宽度
                width += DGVFiles.Columns[i].Width;
            }
            //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度
            //则将每列都自动调整模式设置为显示的列即可
            //如果是小于原来设定的宽度，将模式改为填充
            if (width > DGVFiles.Size.Width)
            {
                DGVFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                DGVFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            //冻结某列从左开始
            DGVFiles.Columns[1].Frozen = true;
        }
    }
}
