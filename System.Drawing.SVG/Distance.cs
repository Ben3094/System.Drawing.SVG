using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.Drawing.SVG
{
    public enum DistanceUnit
    {
        inch,
        cm,
        mm,
        pt, //Pica point = 1/12 pica
        pc, //Pica = 1/6 inch
        px,
        percent
 }
    public class Distance : INotifyPropertyChanged
    {
        public Distance(DistanceUnit unit) { this.unit = unit; }
        private DistanceUnit unit = DistanceUnit.px;
        public DistanceUnit Unit { get { return this.unit; } }

        /// <summary>
        /// Default value
        /// </summary>
        public const float DISTANCE_LACUNA_VALUE = 0;
        private float value = DISTANCE_LACUNA_VALUE;

        public float Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
