using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataContextTest
{
    using System;
    using System.Linq;
    using HRMSystem.Models;
    using HRMSystem.Controllers;
    using System.Collections.Generic;

    //[TestClass]
    public class SqlDataTest
    {
        private HRMSystemEntities db = new HRMSystemEntities();
        private List<Employee> employees = new List<Employee>();
        private Employee employee1 = new Employee();
        private Employee employee2 = new Employee();
        private Employee employee3 = new Employee();

        protected void SetupTest1()
        {
            this.employees = this.db.Employees.ToList();
        }
        protected void SetupTest2()
        {
            this.employee1 = db.Employees.FirstOrDefault(k => k.Id == 1);
        }
        protected void SetupTest3(int id)
        {
            this.employee2 = db.Employees.FirstOrDefault(k => k.Id == id);
        }
        //[TestMethod]
        public void TestAdd1()
        {
            this.employee1.Id = 2;
            this.employee1.Name = "Nguyễn Minh Trí";
            this.employee1.Dob = new DateTime(2003, 09, 17);
            this.employee1.Address = "42/17 Hồ Thị Kỷ";
            this.employee1.Phone = "0900009900";
            this.employee1.IdPosition = 2;
            this.employee1.IdEduType = 1;
            this.employee1.IdState = 1;
            bool actualStatus = EmployeesDAO.Add(this.employee1);
            bool expectedStatus = true;

            Assert.AreEqual(expectedStatus, actualStatus);
        }
        //[TestMethod]
        public void TestAdd2()
        {
            this.employee2.Id = 3;
            this.employee2.Name = "Nguyễn Phát Hưng";
            this.employee2.Dob = new DateTime(2003, 1, 27);
            this.employee2.Address = "111/6 Tân Trang";
            this.employee2.Phone = "0900009901";
            this.employee2.IdPosition = 8; 
            this.employee2.IdEduType = 1;
            this.employee2.IdState = 1;
            bool actualStatus = EmployeesDAO.Add(this.employee2);
            bool expectedStatus = true;

            Assert.AreEqual(expectedStatus, actualStatus);
        }
        [TestMethod]
        public void TestAdd3()
        {
            this.employee3.Id = 4;
            this.employee3.Name = "Nguyễn Thị Ngọc Hân";
            this.employee3.Dob = new DateTime(2003, 4, 10);
            this.employee3.Address = "168/38C D2";
            this.employee3.Phone = "0900009902";
            this.employee3.IdPosition = 1;
            this.employee3.IdEduType = 1;
            this.employee3.IdState = 1;

            bool actualStatus = EmployeesDAO.Add(this.employee3);
            bool expectedStatus = true;

            Assert.AreEqual(expectedStatus, actualStatus);
        }
        // [TestMethod]
        public void TestDataCount()
        {
            SetupTest1();

            Assert.IsTrue(this.employees.Count >= 0);
        }
        // [TestMethod]
        public void TestEdit1()
        {
            SetupTest3(2);
            this.employee2.IdPosition = 4;
            bool actualStatus = EmployeesDAO.Edit(this.employee2);
            bool expectedStatus = true;

            Assert.AreEqual(expectedStatus, actualStatus);
        }
    }
}
