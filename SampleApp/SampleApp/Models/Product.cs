using SampleApp.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace SampleApp.Models
{
    public class Product : INotifyPropertyChanged
    {
        private int _Id;
        private string _Name;
        private string _Description;
        private decimal _Price;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Id should not be empty")]
        [Range(1, 1000,ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                SetProperty(ref _Id, value);
            }
        }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name should not be empty")]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                SetProperty(ref _Name, value);
            }
        }
        [DataType(DataType.MultilineText)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description should not be empty")]
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                SetProperty(ref _Description, value);
            }
        }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Id should not be empty")]
        [Range(1, 10000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal Price
        {
            get
            {
                return _Price;
            }
            set
            {
              SetProperty(ref _Price, value);
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
            {
                if (EqualityComparer<T>.Default.Equals(backingStore, value))
                    return false;

                backingStore = value;
                onChanged?.Invoke();
                OnPropertyChanged(propertyName);
                return true;
            }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
