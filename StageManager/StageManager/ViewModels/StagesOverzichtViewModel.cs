using Caliburn.Micro;
using StageManager.Models;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.ViewModels
{
    class StagesOverzichtViewModel : PropertyChanged
    {
        private Dictionary<Object, dbstageviewcomplete> list;
        Dictionary<Object, dbstageviewcomplete> List
        {
            get
            {
                return list;
            }
            set
            {
                list = value;
                GridContents = value.Keys.ToList();
                NotifyOfPropertyChange(() => List);
            }
        }

        private List<Object> gridContents;
        public List<object> GridContents
        {
            get
            {
                return gridContents;
            }
            set
            {
                gridContents = value;
                NotifyOfPropertyChange(() => GridContents);
            }
        }

       

        

        public StagesOverzichtViewModel(MainViewModel main)
            : base(main)
        {
            List = new Dictionary<object, dbstageviewcomplete>();
            List = new WStored().SearchDBStageViewComplete().ToDictionary(t => (Object)new
            {

                /*
                Studentnummer = t.studentnumber,
                Voornaam = t.users.name,
                Achternaam = t.users.surname,
                Opleiding = t.users.students.education.name,
                Telefoonnummer = t.users.phonenumber,
                Voldoet = t.users.students.meets,
                Email = t.users.email,
                EmailURL = t.users.email,
                Straatnaam = t.users.students.adresses.street,
                Huisnummer = t.users.students.adresses.housenumber,
                Postcode = t.users.students.adresses.zipcode,
                Woonplaats = t.users.students.adresses.place,
                  
                 <DataGrid.Columns>
                                    <DataGridTextColumn Binding="{Binding Stagetype}" Header="Stage type" Width="auto" IsReadOnly="True"/>
                                    <DataGridTextColumn Binding="{Binding Eerstestudent}" Header="Student 1" Width="auto" IsReadOnly="True"/>
                                    <DataGridTextColumn Binding="{Binding Tweedestudent}" Header="Student 2" Width="auto" IsReadOnly="True"/>
                                    <DataGridTextColumn Binding="{Binding Stagebegeleider}" Header="Stagebegeleider" Width="auto" IsReadOnly="True"/>
                                    <DataGridTextColumn Binding="{Binding Tweedelezer}" Header="Tweede lezer" Width="auto" IsReadOnly="True"/>
                                    <DataGridTextColumn Binding="{Binding Bedrijf}" Header="Bedrijf" Width="auto" IsReadOnly="True"/>
                                    <DataGridTextColumn Binding="{Binding Bedrijfsbegeleider}" Header="Bedrijfsbegeleider" Width="auto" IsReadOnly="True"/>
                                    <DataGridTextColumn Binding="{Binding Begin}" Header="Begin Datum" Width="auto" IsReadOnly="True"/>
                                    <DataGridTextColumn Binding="{Binding Eind}" Header="Eind Datum" Width="auto" IsReadOnly="True"/>
                                </DataGrid.Columns>
                 */

                Stagetype = t.type,
                Eerstestudent = t.name,
                Tweedestudent = " TODO ",
                Stagebegeleider = t.teacher_name,
                Tweedelezer = t.sr_name,
                Bedrijf = t.company_name,
                Bedrijfsbegeleider = t.sv_name,
                Begin = t.start_date,
                Eind = t.end_date,

            }, t => t);

        }
    }
}
