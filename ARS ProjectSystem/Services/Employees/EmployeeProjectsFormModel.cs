﻿namespace ARS_ProjectSystem.Services.Employees
{
    using System.Collections.Generic;
    public class EmployeeProjectsFormModel
    {
        public int Id { get; set; }
        public IEnumerable<EmployeeProjectsServiceModel> Projects { get; set; }
    }
}