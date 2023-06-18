using Acr.UserDialogs;
using MobileHelper.Models;
using MobileHelper.Models.Tables;
using MobileHelper.Services;
using MobileHelper.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileHelper.ViewModels.ConstructorViewModels
{
    public class CreatedViewModel : BaseViewModel
    {
        public ICommand Remove { get; set; }
        public ICommand Edit { get; set; }
        public ObservableCollection<Items> Elements { get; set; }
        private SqliteDB DBHelper { get; set; }
        private int currentId { get; set; }
        public CreatedViewModel()
        {

        }

        public CreatedViewModel(INavigation navigation, int id)
        {
            Title = "Техника";
            Navigation = navigation;
            Finish = new Command(ToFinish);
            Theory = new Command(ToTheory);
            Remove = new Command(ToRemove);
            Edit = new Command(ToEdit);
            Elements = new ObservableCollection<Items>();
            DBHelper = new SqliteDB();
            currentId = id;

            PrepareItems();

        }

        private async void ToEdit(object obj)
        {
            await Navigation.PushAsync(new DesignerPage(currentId));
        }

        private void ToRemove(object obj)
        {
            ConfirmConfig confirmConfig = new ConfirmConfig();
            confirmConfig.SetTitle("Mobile Helper");
            confirmConfig.SetOkText("Да");
            confirmConfig.SetCancelText("Нет");
            confirmConfig.SetMessage("Вы уверены, что хотите удалить свою технику?");
            confirmConfig.OnConfirm += async (result) =>
            {
                if (result)
                {
                    var list = await DBHelper.GetListAsync<Technique>();
                    list.RemoveAt(currentId);

                    await DBHelper.DeleteAllAsync<Technique>();
                    await DBHelper.InsertAllAsync(list);

                    MessagingCenter.Send(this, "remove", currentId);

                    await Navigation.PopAsync();
                }
            };
            UserDialogs.Instance.Confirm(confirmConfig);

        }

        private Task<string[]> PrepareItems()
        {
            return Task.Run(async () =>
            {

                var item = await DBHelper.GetElementById<Technique>(currentId);
                var data = item.Algorithm;

                string[] result = data.Split('\n');

                int i = 0;

                foreach (string s in result)
                {
                    Elements.Add(new Items
                    {
                        Id = i,
                        Text = s
                    });
                    i++;
                }

                return result;

            });
        }

        private async void ToFinish(object obj)
        {
            await Navigation.PopAsync();
        }
    }
}
