using System;
using System.Linq;
using HRMSystem.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace HRMSystem.DAOs
{
    public class PositionTypeDAO
    {
        private static HRMSystemEntities db = new HRMSystemEntities();

        public static int Count
        {
            get => db.PositionTypes.ToList().Count;
        }
        public static List<PositionType> Data { get => db.PositionTypes.ToList(); }

        public static bool Add(PositionType positionType)
        {
            try
            {
                if (positionType != null)
                {
                    db.PositionTypes.Add(positionType);
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public static PositionType Load(int id)
        {
            try
            {
                PositionType positionType = db.PositionTypes.FirstOrDefault(k => k.IdPosition == id);
                if (positionType != null)
                {
                    return positionType;
                }

                return new PositionType();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new PositionType();
            }
        }
        public static bool Edit(PositionType positionType)
        {
            try
            {
                if (positionType != null)
                {
                    db.Entry(positionType).State = EntityState.Modified;
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public static bool Delete(int id)
        {
            try
            {
                PositionType positionType = db.PositionTypes.FirstOrDefault(k => k.IdPosition == id);
                if (positionType != null)
                {
                    db.Entry(positionType).State = EntityState.Deleted;
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
    }
}
