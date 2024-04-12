
using CRUDSakilaConsoleApp.Infrastructure;
using CRUDSakilaConsoleApp.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

// CRUDEFCore();

CRUDDapper();


static void CRUDDapper()
{
    Console.WriteLine("Hello, CRUD Dapper!");

    var connectionString = "Data Source=DESKTOP-RB5EAJ4\\SQLEXPRESS;Initial Catalog=sakila;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Application Name=SakilaConsoleApp";
    
    using IDbConnection db = new SqlConnection(connectionString);
    
    string title = "BINGO TALENTED";

    #region SQL
    const string sqlGetInventoryByFilmTitle = """
        SELECT TOP(1)
            inventory_id AS InventoryId,
            film_id AS FilmId,
            store_id AS StoreId
        FROM 
            inventory 
        WHERE 
            film_id = ( SELECT film_id FROM film where [title] = @Title)
    
    """;

   
    const string sqlGetCustomerByFirstName = """

        SELECT TOP(1) 
    	customer_id AS CustomerId,
    	first_name AS FirstName,
    	last_name AS LastName
    FROM customer
    	WHERE first_name = @FirstName

    """;

    const string sqlGetStaffFirst = """
    SELECT TOP(1)
    staff_id AS StaffId,
    first_name AS FirstName,
    last_name AS LastName FROM staff	
    """;

    //const string sqlAddRental = """
    //INSERT INTO rental (rental_date, inventory_id, customer_id, return_date, staff_id, last_update)
    //OUTPUT inserted.rental_id 
    //VALUES (@rental_date, @inventory_id, @customer_id, @return_date, @staff_id, @last_update)
    //""";

    const string sqlAddRental = """
    INSERT INTO rental (rental_date, inventory_id, customer_id, return_date, staff_id, last_update)
    OUTPUT inserted.rental_id 
    VALUES (@RentalDate, @InventoryId, @CustomerId, @ReturnDate, @StaffId, @LastUpdate)
    """;

    //const string sqlAddPayment = """
    //INSERT INTO payment (customer_id, staff_id, rental_id, amount, payment_date, last_update)
    //OUTPUT inserted.payment_id
    //VALUES (@customer_id, @staff_id, @rental_id, @amount, @payment_date, @last_update)
    //""";

    const string sqlAddPayment = """
    INSERT INTO payment (customer_id, staff_id, rental_id, amount, payment_date, last_update)
    OUTPUT inserted.payment_id
    VALUES (@CustomerId, @StaffId, @RentalId, @Amount, @PaymentDate, @LastUpdate)
    """;

    #endregion

    var parameters = new { @Title = title, @FirstName = "TOM" };

    Inventory selectedInventory = db.QueryFirst<Inventory>(sqlGetInventoryByFilmTitle, parameters);

    if (selectedInventory != null)
    {
        var selectedCustomer = db.QueryFirst<Customer>(sqlGetCustomerByFirstName, parameters);
        var selectedStaff = db.QueryFirst<Staff>(sqlGetStaffFirst, parameters);

        DateTime currentDate = DateTime.Now;

        Rental newRental = new Rental
        {
            Customer = selectedCustomer,
            CustomerId = selectedCustomer.CustomerId,
            Inventory = selectedInventory,
            InventoryId = selectedInventory.InventoryId,
            RentalDate = currentDate,
            LastUpdate = currentDate,
            Staff = selectedStaff,
            StaffId = selectedStaff.StaffId,
        };      

        Payment newPayment = new Payment
        {
            Rental = newRental,
            Customer = selectedCustomer,
            CustomerId = selectedCustomer.CustomerId,
            PaymentDate = currentDate,            
            LastUpdate = currentDate,
            Staff = selectedStaff,
            StaffId = selectedStaff.StaffId,
            Amount = 10m
        };

        using var transaction = db.BeginTransaction();
        newRental.RentalId = db.QuerySingle<int>(sqlAddRental, newRental);
        newPayment.PaymentId = db.QuerySingle<int>(sqlAddPayment, newPayment);
        transaction.Commit();

        //DynamicParameters addPaymentParameters = new DynamicParameters();
        //addPaymentParameters.Add("@customer_id", newPayment.Customer.CustomerId);
        //addPaymentParameters.Add("@staff_id", newPayment.Staff.StaffId);
        //addPaymentParameters.Add("@rental_id", newPayment.Rental.RentalId);
        //addPaymentParameters.Add("@amount", newPayment.Amount);
        //addPaymentParameters.Add("@payment_date", newPayment.PaymentDate);
        //addPaymentParameters.Add("@last_update", newPayment.LastUpdate);

        //newPayment.PaymentId = db.QuerySingle<int>(sqlAddPayment, addPaymentParameters);

    } // Wywołana zostanie metoda Dispose, która zamknie połączenie do bazy danych
}

static void CRUDEFCore()
{
    using SakilaContext db = new SakilaContext();
    string title = "BINGO TALENTED";

    Inventory selectedInventory = db.Inventories
        .Where(i => i.Film.Title == title)
        .FirstOrDefault(); ;

    var selectedCustomer = db.Customers.SingleOrDefault(c => c.FirstName == "TOM");
    var selectedStaff = db.Staff.First();
    var currentDate = DateTime.Now;

    if (selectedInventory != null)
    {
        Rental newRental = new Rental
        {
            Customer = selectedCustomer,
            Inventory = selectedInventory,
            RentalDate = currentDate,
            LastUpdate = currentDate,
            Staff = selectedStaff,
        };

        Payment newPayment = new Payment
        {
            Rental = newRental,
            Customer = selectedCustomer,
            PaymentDate = currentDate,
            LastUpdate = currentDate,
            Staff = selectedStaff,
            Amount = 10m
        };


        db.Rentals.Add(newRental);
        db.Payments.Add(newPayment);

        db.SaveChanges();
    } 
}


static void ChangeTrackerEFCore()
{
    Console.WriteLine("Hello, CRUD EF Core!");

    // CRUD = (C)reate (R)ead (U)pdate (D)elete

    Inventory selectedInventory = null;

    using (SakilaContext db = new SakilaContext())
    {
        // Console.Write("Podaj tytuł: ");
        string title = "BINGO TALENTED";

        selectedInventory = db.Inventories
            .Where(i => i.Film.Title == title)
            .FirstOrDefault();
    }

    using (SakilaContext db = new SakilaContext())
    {
        // Wyłączamy globalnie automatyczne śledzenie encji (obiektu)
        // db.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;

        // Wyłączamy automatyczne wykrywanie zmian właściwości encji (obiektu)
        // db.ChangeTracker.AutoDetectChangesEnabled = true;

        // (R)ead
        var films = db.Films.AsNoTracking().ToList();

        // Hint: tabele słownikowe - zastosuj AsNoTracking()

        foreach (var film in films)
        {
            Console.WriteLine(film.Title);
        }

        var cacheFilms = db.Films.Local;

        var selectedCustomer = db.Customers.SingleOrDefault(c => c.FirstName == "TOM");
        var selectedStaff = db.Staff.First();
        var currentDate = DateTime.Now;

        if (selectedInventory != null)
        {
            Rental newRental = new Rental
            {
                Customer = selectedCustomer,
                Inventory = selectedInventory,
                RentalDate = currentDate,
                LastUpdate = currentDate,
                Staff = selectedStaff,
            };

            Payment newPayment = new Payment
            {
                Rental = newRental,
                Customer = selectedCustomer,
                PaymentDate = currentDate,
                LastUpdate = currentDate,
                Staff = selectedStaff,
                Amount = 10m
            };

            Console.WriteLine(db.ChangeTracker.DebugView.LongView);

            // DisplayStates(db, newRental, newPayment, selectedCustomer, selectedStaff, selectedInventory);

            db.Payments.Add(newPayment);
            db.Rentals.Add(newRental);

            db.Entry(selectedInventory).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            //db.Entry(selectedCustomer).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            //db.Entry(selectedStaff).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;

            Console.WriteLine(db.ChangeTracker.DebugView.LongView);

            // DisplayStates(db, newRental, newPayment, selectedCustomer, selectedStaff, selectedInventory);


            db.SaveChanges();

            Console.WriteLine(db.ChangeTracker.DebugView.LongView);
            // DisplayStates(db, newRental, newPayment, selectedCustomer, selectedStaff, selectedInventory);

            Console.WriteLine("Press any key to change the amount");
            Console.ReadKey();

            var amountProperty = db.Entry(newPayment).Property(p => p.Amount);
            Console.WriteLine(amountProperty.OriginalValue);
            Console.WriteLine(amountProperty.CurrentValue);
            Console.WriteLine(amountProperty.IsModified);

            newPayment.Amount = 9m;

            db.ChangeTracker.DetectChanges();

            Console.WriteLine(amountProperty.OriginalValue);
            Console.WriteLine(amountProperty.CurrentValue);
            Console.WriteLine(amountProperty.IsModified);

            Console.WriteLine(db.ChangeTracker.DebugView.LongView);

            db.SaveChanges(); // Samodzielnie uruchamia metodę db.ChangeTracker.DetectChanges()

            Console.WriteLine(db.ChangeTracker.DebugView.LongView);

            newPayment.LastUpdate = currentDate.AddMinutes(1);
            Console.WriteLine(db.ChangeTracker.DebugView.LongView);

            db.SaveChanges();

            Console.WriteLine(db.ChangeTracker.DebugView.LongView);


            db.Remove(newRental);
            Console.WriteLine(db.ChangeTracker.DebugView.LongView);

            db.SaveChanges();

            Console.WriteLine(db.ChangeTracker.DebugView.LongView);

        } // db.Dispose();

    }
}

