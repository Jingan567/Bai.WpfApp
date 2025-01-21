using Microsoft.Expression.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Bai.WpfApp
{
    public class LiuProgressBar : ProgressBar
    {
        private Arc PART_ARC;

        public double Percentage
        {
            get { return (double)GetValue(PercentageProperty); }
            private set { SetValue(PercentageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Percentage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PercentageProperty =
            DependencyProperty.Register("Percentage", typeof(double), typeof(LiuProgressBar));

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            PART_ARC = GetTemplateChild("PART_ARC") as Arc;
            Refresh();
        }
        protected override void OnValueChanged(double oldValue, double newValue)
        {
            base.OnValueChanged(oldValue, newValue);
            Refresh();
        }
        /// <summary>
        /// 刷新界面
        /// </summary>
        private void Refresh()
        {
            Percentage = Value / Maximum * 100;
            if (PART_ARC != null)
            {
                PART_ARC.EndAngle = Percentage * 360 / 100;
            }
        }
    }
}
