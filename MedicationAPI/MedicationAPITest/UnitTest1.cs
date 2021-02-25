using MedicationAPI.Controllers;
using MedicationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MedicationAPITest
{
  public class UnitTest1
  {
    private chdbContext context;

    public UnitTest1()
    {
      var options = new DbContextOptionsBuilder<chdbContext>().UseInMemoryDatabase(databaseName: "Medication_tests").Options;
      context = new chdbContext(options);


      // Use the in memory data added here to be used for testing. Should not ever test directly on the database.
      context.Medications.AddRange(
        new Medication
        {
          MedicationId = 1,
          MedicationDescription = "Pain Reliever",
          MedicationCost = 1.0M
        },
        new Medication
        {
          MedicationId = 2,
          MedicationDescription = "Ibuprofen",
          MedicationCost = 1.23M
        },
        new Medication
        {
          MedicationId = 3,
          MedicationDescription = "Advil",
          MedicationCost = 1.47M
        }
      );

      context.SaveChanges();
    }

    [Fact]
    public async Task Get_NoInput_ReturnsMedications()
    {
      //ASSERT
      var medicationsController = new MedicationsController(context);

      //ACT
      var actionResult =  await medicationsController.GetMedications();

      //ARRANGE
      Assert.IsType<ActionResult<IEnumerable<Medication>>>(actionResult);
      var genericMedications = actionResult.Value;
      var medications = genericMedications as List<Medication>;
      Assert.Equal(3, medications.Count);
      Assert.Equal(1, medications[0].MedicationId);
      Assert.Equal("Ibuprofen", medications[1].MedicationDescription);
      Assert.Equal(1.47M, medications[2].MedicationCost);
    }
  }
}
