using Marketing.LOB.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Marketing.LOB.ViewModels
{
    public class ClientFormViewModel : BindableBase
    {
        #region Properties and Fields
        public Client Client { get; set; }

        public DelegateCommand Create { get; }

        private bool isloading = true;
        #endregion

        #region Constructor
        public ClientFormViewModel()
        {
            Client = new Client();
            Create = new DelegateCommand(CreateClient, CanCreate);
            Client.PropertyChanged += Client_PropertyChanged;
            Client.ErrorsChanged += Client_ErrorsChanged;
        }
        #endregion

        #region Validation
        private void Client_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            Create.RaiseCanExecuteChanged();
        }

        private void Client_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Create.RaiseCanExecuteChanged();
        }

        private bool CanCreate()
        {
            if (isloading)
            {
                isloading = false;
                return false;
            }

            //This do not validate only checks
            //return Client.Errors.Errors.Count == 0;
            //This validates and updates UI
            //return Client.ValidateProperties();
            //This check if it is valid;
            return Client.IsValid();
        }
        #endregion

        private void CreateClient()
        {
            //To be continue in the next post
        }

    }
}
