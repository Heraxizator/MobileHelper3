using Acr.UserDialogs;
using MobileHelper.Models;
using MobileHelper.Models.DataItems;
using MobileHelper.Models.Tables;
using MobileHelper.Services;
using MobileHelper.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            this.Title = "Техника";
            this.Navigation = navigation;
            this.Finish = new Command(ToFinish);
            this.Theory = new Command(ToTheory);
            this.Remove = new Command(ToRemove);
            this.Edit = new Command(ToEdit);
            this.Elements = new ObservableCollection<Items>();
            this.DBHelper = new SqliteDB();
            this.currentId = id;

            _ = PrepareItems();

        }

        private async void ToEdit(object obj)
        {
            await this.Navigation.PushAsync(new DesignerPage(this.currentId));
        }

        private void ToRemove(object obj)
        {
            ConfirmConfig confirmConfig = new ConfirmConfig();
            _ = confirmConfig.SetTitle("Mobile Helper");
            _ = confirmConfig.SetOkText("Да");
            _ = confirmConfig.SetCancelText("Нет");
            _ = confirmConfig.SetMessage("Вы уверены, что хотите удалить свою технику?");
            confirmConfig.OnConfirm += async (result) =>
            {
                if (result)
                {
                    List<Technique> list = await this.DBHelper.GetListAsync<Technique>();
                    list.RemoveAt(this.currentId);

                    await this.DBHelper.DeleteAllAsync<Technique>();
                    await this.DBHelper.InsertAllAsync(list);

                    MessagingCenter.Send(this, "remove", this.currentId);

                    _ = await this.Navigation.PopAsync();
                }
            };
            UserDialogs.Instance.Confirm(confirmConfig);

        }

        private Task<string[]> PrepareItems()
        {
            return Task.Run(async () =>
            {

                Technique item = await this.DBHelper.GetElementById<Technique>(this.currentId);
                string data = item.Algorithm;

                string[] result = data.Split('\n');

                int i = 0;

                foreach (string s in result)
                {
                    this.Elements.Add(new Items
                    {
                        Id = i,
                        Text = s
                    });
                    i++;
                }

                return result;

            });
        }

        private new async void ToFinish(object obj)
        {
            _ = await this.Navigation.PopAsync();
        }
    }
}
