using VinylShop.EfCore;

namespace VinylShop.Model
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }

        /* VINYLS */
        
        public List<VinylModel> GetVinyls()
        {
            List<VinylModel> response = new List<VinylModel>();
            var dataList = _context.Vinyls.ToList();
            dataList.ForEach(row => response.Add(new VinylModel()
            {
                VinylId = row.VinylId,
                Title = row.Title,
                Artist = row.Artist,
                Format = row.Format,
                ReleaseYear = row.ReleaseYear,
                Genre = row.Genre,
                Label = row.Label,
                CatalogueNum = row.CatalogueNum,
            }));
            return response;
        }
        public VinylModel GetVinylsById(int id)
        {
            VinylModel response = new VinylModel();
            var row = _context.Vinyls.Where(d => d.VinylId.Equals(id)).FirstOrDefault();
            return new VinylModel()
            {
                VinylId = row.VinylId,
                Title = row.Title,
                Artist = row.Artist,
                Format = row.Format,
                ReleaseYear = row.ReleaseYear,
                Genre = row.Genre,
                Label = row.Label,
                CatalogueNum = row.CatalogueNum,
            };
        }
        public void SaveVinyl(VinylModel vinylModel)
        {
            Vinyl dbTable = new Vinyl();
            if (vinylModel.VinylId > 0)
            {
                dbTable = _context.Vinyls.Where(d => d.VinylId.Equals(vinylModel.VinylId)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.Title = vinylModel.Title;
                    dbTable.Artist = vinylModel.Artist;
                    dbTable.Format = vinylModel.Format;
                    dbTable.ReleaseYear = vinylModel.ReleaseYear;
                    dbTable.Genre = vinylModel.Genre;
                    dbTable.Label = vinylModel.Label;
                    dbTable.CatalogueNum = vinylModel.CatalogueNum;
                }
            }
            else
            {
                dbTable.VinylId = vinylModel.VinylId;
                dbTable.Title = vinylModel.Title;
                dbTable.Artist = vinylModel.Artist;
                dbTable.Format = vinylModel.Format;
                dbTable.ReleaseYear = vinylModel.ReleaseYear;
                dbTable.Genre = vinylModel.Genre;
                dbTable.Label = vinylModel.Label;
                dbTable.CatalogueNum = vinylModel.CatalogueNum;
                _context.Vinyls.Add(dbTable);
            }
            _context.SaveChanges();
        }
        public void DeleteVinyl(int id)
        {
            var vinyl = _context.Vinyls.Where(d => d.VinylId.Equals(id)).FirstOrDefault();
            if(vinyl != null)
            {
                _context.Vinyls.Remove(vinyl);
                _context.SaveChanges();
            }
        }


        /* CUSTOMERS */

        public List<CustomerModel> GetCustomers()
        {
            List<CustomerModel> response = new List<CustomerModel>();
            var dataList = _context.Customers.ToList();
            dataList.ForEach(row => response.Add(new CustomerModel()
            {
                CustId = row.CustId,
                FirstName = row.FirstName,
                LastName = row.LastName,
                Adress = row.Adress,
                PhoneNum = row.PhoneNum,
            }));
            return response;
        }
        public CustomerModel GetCustomerById(int id)
        {
            CustomerModel response = new CustomerModel();
            var row = _context.Customers.Where(d => d.CustId.Equals(id)).FirstOrDefault();
            return new CustomerModel()
            {
                CustId = row.CustId,
                FirstName = row.FirstName,
                LastName = row.LastName,
                Adress = row.Adress,
                PhoneNum = row.PhoneNum,
            };
        }
        public void SaveCustomer(CustomerModel customerModel)
        {
            Customer dbTable = new Customer();
            if (customerModel.CustId > 0)
            {
                dbTable = _context.Customers.Where(d => d.CustId.Equals(customerModel.CustId)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.FirstName = customerModel.FirstName;
                    dbTable.LastName = customerModel.LastName;
                    dbTable.Adress = customerModel.Adress;
                    dbTable.PhoneNum = customerModel.PhoneNum;
                }
            }
            else
            {
                dbTable.CustId = customerModel.CustId;
                dbTable.FirstName = customerModel.FirstName;
                dbTable.LastName = customerModel.LastName;
                dbTable.Adress = customerModel.Adress;
                dbTable.PhoneNum = customerModel.PhoneNum;
                _context.Customers.Add(dbTable);
            }
            _context.SaveChanges();
        }
    
        

        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.Where(d => d.CustId.Equals(id)).FirstOrDefault();
            if(customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }
        
        /* HIRES */

        public List<HireModel> GetHires()
        {
            List<HireModel> response = new List<HireModel>();
            var dataList = _context.Hires.ToList();
            dataList.ForEach(row => response.Add(new HireModel()
            {
                HireId = row.HireId,
                VinylId = row.VinylId,
                CustId = row.CustId,
                HireDate = row.HireDate,
                ReturnDate = row.ReturnDate,
                IsClosed = row.IsClosed,
            }));
            return response;
        }
        public HireModel GetHireById(int id)
        {
            HireModel response = new HireModel();
            var row = _context.Hires.Where(d => d.HireId.Equals(id)).FirstOrDefault();
            return new HireModel()
            {
                HireId = row.HireId,
                VinylId = row.VinylId,
                CustId = row.CustId,
                HireDate = row.HireDate,
                ReturnDate = row.ReturnDate,
                IsClosed = row.IsClosed,
            };
        }
        public void SaveHire(HireModel hireModel)
        {
            Hire dbTable = new Hire();
            if (hireModel.HireId > 0)
            {
                dbTable = _context.Hires.Where(d => d.HireId.Equals(hireModel.HireId)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.VinylId = hireModel.VinylId;
                    dbTable.CustId = hireModel.CustId;
                    dbTable.HireDate = hireModel.HireDate;
                    dbTable.ReturnDate = hireModel.ReturnDate;
                    dbTable.IsClosed = hireModel.IsClosed;
                }
            }
            else
            {
                dbTable.HireId = hireModel.HireId;
                dbTable.VinylId = hireModel.VinylId;
                dbTable.CustId = hireModel.CustId;
                dbTable.HireDate = hireModel.HireDate;
                dbTable.ReturnDate = hireModel.ReturnDate;
                dbTable.IsClosed = hireModel.IsClosed;
                _context.Hires.Add(dbTable);
            }
            _context.SaveChanges();
        }
    
        

        public void DeleteHire(int id)
        {
            var hire = _context.Hires.Where(d => d.HireId.Equals(id)).FirstOrDefault();
            if(hire != null)
            {
                _context.Hires.Remove(hire);
                _context.SaveChanges();
            }
        }

        /* EMPLOYEES */

        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> response = new List<EmployeeModel>();
            var dataList = _context.Employees.ToList();
            dataList.ForEach(row => response.Add(new EmployeeModel()
            {
                EmpId = row.EmpId,
                FirstName = row.FirstName,
                LastName = row.LastName,
                Adress = row.Adress,
                PhoneNum = row.PhoneNum,
            }));
            return response;
        }
        public EmployeeModel GetEmployeeById(int id)
        {
            EmployeeModel response = new EmployeeModel();
            var row = _context.Employees.Where(d => d.EmpId.Equals(id)).FirstOrDefault();
            return new EmployeeModel()
            {
                EmpId = row.EmpId,
                FirstName = row.FirstName,
                LastName = row.LastName,
                Adress = row.Adress,
                PhoneNum = row.PhoneNum,
            };
        }
        public void SaveEmployee(EmployeeModel employeeModel)
        {
            Employee dbTable = new Employee();
            if (employeeModel.EmpId > 0)
            {
                dbTable = _context.Employees.Where(d => d.EmpId.Equals(employeeModel.EmpId)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.FirstName = employeeModel.FirstName;
                    dbTable.LastName = employeeModel.LastName;
                    dbTable.Adress = employeeModel.Adress;
                    dbTable.PhoneNum = employeeModel.PhoneNum;
                }
            }
            else
            {
                dbTable.EmpId = employeeModel.EmpId;
                dbTable.FirstName = employeeModel.FirstName;
                dbTable.LastName = employeeModel.LastName;
                dbTable.Adress = employeeModel.Adress;
                dbTable.PhoneNum = employeeModel.PhoneNum;
                _context.Employees.Add(dbTable);
            }
            _context.SaveChanges();
        }
    
        

        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Where(d => d.EmpId.Equals(id)).FirstOrDefault();
            if(employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}
