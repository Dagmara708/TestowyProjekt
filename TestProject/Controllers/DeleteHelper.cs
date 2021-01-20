using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject.Models;

namespace TestProject.Controllers
{
    public static class DeleteHelper
    {
        private static Context context;

        static DeleteHelper()
        {
            context = new Context();
        }

        public static void DeletePatient(int id)
        {
            Patient tmp = context.Patients.FirstOrDefault(x => x.Patient_id == id);
            //foreach (var item in tmp.FeverCards)
            for (int i = 0; i< tmp.FeverCards.Count; i++)
            {
                DeleteFeverCard(tmp.FeverCards[i].Card_id);
            }
            context.Patients.Remove(tmp);
        }

        public static void DeleteFeverCard(int id)
        {
            FeverCard tmp = context.FeverCards.FirstOrDefault(x => x.Card_id == id);
            //foreach (var item in tmp.Measures)
            for(int i = 0; i< tmp.Measures.Count; i++)
            {
                DeleteMeasure(tmp.Measures[i].Measure_id);
            }
            context.FeverCards.Remove(tmp);
        }

        public static void DeleteMeasure(int id)
        {
            Measure tmp = context.Measures.FirstOrDefault(x => x.Measure_id == id);
            context.Measures.Remove(tmp);

        }

        public static void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}