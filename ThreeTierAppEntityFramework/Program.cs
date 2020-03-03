using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer;
using PresentationLayer.Controllers;
using DataAccessLayer.Models;
using BusinessLogicLayer.Models;
using PresentationLayer.Models;
using DataAccessLayer.Repositories;
using BusinessLogicLayer.Services;
using System.Text.RegularExpressions;

namespace ThreeTierAppEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            ManufacturerController manufacturerController = new ManufacturerController();

            CarController carController = new CarController();

            var all = manufacturerController.GetAll();


        }

    }
}
