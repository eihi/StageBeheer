﻿using Caliburn.Micro;
using StageManager.Models;
using StageManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageManager.ViewModels
{
    class StagesOverzichtViewModel : PropertyChanged, IExcelAlgorithm
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
            List<dbstageviewcomplete> tempList = (from stage in new WStored().SearchDBStageViewComplete() select stage).ToList();

            for (int i = 0; i < tempList.Count; i++)
            {
                String tweedeStudent = "";
                if (i < tempList.Count - 1 && tempList[i].internshipID == tempList[i + 1].internshipID)
                {
                    tweedeStudent = tempList[i].name + " " + tempList[i].surname;
                    i++;
                }
                object o = (Object)new
                {                   
                    Stagetype = tempList[i].type == "0" ? "Stage" : "Eindstage",
                    Eerstestudent = tempList[i].name + " " + tempList[i].surname,
                    Tweedestudent = tweedeStudent,
                    Stagebegeleider = tempList[i].teacher_name + " " + tempList[i].teacher_surname,
                    Tweedelezer = tempList[i].sr_name + " " + tempList[i].sr_surname,
                    Bedrijf = tempList[i].company_name,
                    Bedrijfsbegeleider = tempList[i].sv_name + " " + tempList[i].sv_surname,
                    Begin = tempList[i].start_date.ToString().Substring(0, tempList[i].start_date.ToString().IndexOf(' ')),
                    Eind = tempList[i].end_date.ToString().Substring(0, tempList[i].end_date.ToString().IndexOf(' ')),
                };
                List.Add(o, tempList[i]);
                List = List;
            }
        }

        public void btnExport_Click()
        {
            ExportExcel ee = new ExportExcel(this);
            ee.Export();
        }

        public void createWorksheet(Microsoft.Office.Interop.Excel.Worksheet worksheet)
        {
            LinkedList<object[]> rows = new LinkedList<object[]>();

            string[] columns = { 
                "Stagetype", 
                "Eerstestudent",
                "Tweedestudent",
                "Stagebegeleider",
                "Tweedelezer",
                "Bedrijf",
                "Bedrijfsbegeleider",
                "Begin",
                "Eind"
            };

            foreach (KeyValuePair<Object, dbstageviewcomplete> t in List)
            {
                object[] row = {
                    t.Value.type == "0" ? "Stage" : "Eindstage",
                    t.Value.name + " " + t.Value.surname,
                    "",
                    t.Value.teacher_name + " " + t.Value.teacher_surname,
                    t.Value.sr_name + " " + t.Value.sr_surname,
                    t.Value.sv_name + " " + t.Value.sv_surname,
                    t.Value.company_name,
                    t.Value.start_date,
                    t.Value.end_date,
                };

                rows.AddLast(row);
            }

            ExcelHelper.MultipleRows(worksheet, columns, rows);
        }
    }
}