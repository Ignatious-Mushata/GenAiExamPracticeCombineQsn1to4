// ISM 6225 - GenAi Exam Practice Combine QSN1to4 (Extra Practice: 4 Scenarios)
// Name: Ignatius Mushata U93924209
// All four questions are in this single Program.cs

bool keepRunning = true;

while (keepRunning)
{
    Console.WriteLine();
    Console.WriteLine("===== Practice Menu =====");
    Console.WriteLine("Enter 1-4 to run a question, or 0 to exit.");
    Console.Write("Your choice: ");
    string? choice = Console.ReadLine();

    if (choice == "1") Question1();
    else if (choice == "2") Question2();
    else if (choice == "3") Question3();
    else if (choice == "4") Question4();
    else if (choice == "0") keepRunning = false;
    else Console.WriteLine("Invalid choice. Please enter 0-4.");
}

// =====================================================
// QUESTION 1 - Inventory Reorder Check
// =====================================================
static void Question1()
{
    Console.WriteLine("--- Question 1: Inventory Reorder Check ---");

    // Inventory coverage checker

    decimal ReadNonNegativeDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt + ": ");
            string input = Console.ReadLine() ?? string.Empty;
            try
            {
                decimal value = Convert.ToDecimal(input);
                if (value < 0m)
                {
                    Console.WriteLine("Invalid entry: value must be nonnegative.");
                    continue;
                }
                return value;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input: please enter a numeric value.");
            }
        }
    }

    decimal ReadStrictlyPositiveDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt + " (must be > 0): ");
            string input = Console.ReadLine() ?? string.Empty;
            try
            {
                decimal value = Convert.ToDecimal(input);
                if (value <= 0m)
                {
                    Console.WriteLine("Invalid entry: value must be greater than zero.");
                    continue;
                }
                return value;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input: please enter a numeric value.");
            }
        }
    }

    Console.WriteLine("Inventory Coverage Checker");

    decimal currentInventory = ReadNonNegativeDecimal("Enter current inventory");
    decimal dailyDemand = ReadStrictlyPositiveDecimal("Enter daily demand");
    decimal leadTime = ReadStrictlyPositiveDecimal("Enter lead time in days");
    decimal safetyStock = ReadNonNegativeDecimal("Enter safety stock");

    // Calculate required stock and reorder quantity
    decimal requiredStock = dailyDemand * leadTime + safetyStock;
    requiredStock = Math.Round(requiredStock, 2);

    decimal rawReorder = requiredStock - currentInventory;
    decimal reorderQuantity = rawReorder > 0m ? rawReorder : 0m;
    reorderQuantity = Math.Round(reorderQuantity, 2);

    // Outputs (all labeled)
    Console.WriteLine($"Required stock (daily demand * lead time + safety stock): {requiredStock}");
    Console.WriteLine($"Current inventory: {currentInventory}");
    Console.WriteLine($"Calculated reorder quantity: {reorderQuantity}");

    if (reorderQuantity > 0m)
    {
        Console.WriteLine("Status: Reorder");
    }
    else
    {
        Console.WriteLine("Status: Inventory sufficient");
    }

}

// =====================================================
// QUESTION 2 - Performance Bonus Calculator
// =====================================================
static void Question2()
{
    Console.WriteLine("--- Question 2: Performance Bonus Calculator ---");

    // Employee annual performance bonus calculator (top-level statements)

    string baseSalaryInput;
    string ratingInput;
    decimal baseSalary;
    decimal bonus = 0m;
    decimal bonusPercentage = 0m;
    bool validTier = true;

    Console.WriteLine("Enter the employee's base salary:");
    baseSalaryInput = Console.ReadLine() ?? string.Empty;
    try
    {
        baseSalary = Convert.ToDecimal(baseSalaryInput);
    }
    catch (Exception)
    {
        Console.WriteLine("Invalid salary entry: please enter a numeric value.");
        return;
    }

    if (baseSalary < 0m)
    {
        Console.WriteLine("Base salary must be nonnegative.");
        return;
    }

    Console.WriteLine("Enter the performance rating (1 = Standard, 2 = Exceeds, 3 = Outstanding):");
    ratingInput = Console.ReadLine() ?? string.Empty;
    int rating;
    try
    {
        rating = Convert.ToInt32(ratingInput);
    }
    catch (Exception)
    {
        Console.WriteLine("Invalid rating entry: please enter a numeric value (1, 2, or 3).");
        return;
    }

    if (rating < 0)
    {
        Console.WriteLine("Rating must be nonnegative.");
        return;
    }

    // Determine bonus percentage using if / else if / else
    if (rating == 1)
    {
        bonusPercentage = 0.05m; // 5%
    }
    else if (rating == 2)
    {
        bonusPercentage = 0.10m; // 10%
    }
    else if (rating == 3)
    {
        bonusPercentage = 0.15m; // 15%
    }
    else
    {
        Console.WriteLine("Error: rating must be 1, 2, or 3. Bonus set to zero.");
        bonusPercentage = 0m;
        validTier = false;
    }

    // Calculate bonus
    bonus = decimal.Round(baseSalary * bonusPercentage, 2);

    // Display result using if / else
    if (validTier)
    {
        Console.WriteLine($"Calculated bonus: {bonus.ToString("C")} (at {bonusPercentage:P0})");
    }
    else
    {
        Console.WriteLine("Bonus calculation failed");
    }

}

// =====================================================
// QUESTION 3 - Shipping Cost Calculator
// =====================================================
static void Question3()
{
    Console.WriteLine("--- Question 3: Shipping Cost Calculator ---");

    // Shipping cost estimator - top-level statements

    decimal ReadWeight()
    {
        while (true)
        {
            Console.Write("Enter package weight in pounds: ");
            string? input = Console.ReadLine();
            try
            {
                decimal weight = Convert.ToDecimal(input);
                if (weight <= 0)
                {
                    Console.WriteLine("Warning: weight must be greater than zero.");
                    continue;
                }
                return weight;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: input could not be converted to a number. Please enter a numeric weight.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: the number entered is too large. Enter a smaller numeric value.");
            }
            catch (Exception)
            {
                Console.WriteLine("Error: unexpected error converting the weight. Please try again.");
            }
        }
    }

    int ReadDeliveryType()
    {
        while (true)
        {
            Console.Write("Enter delivery type (1 = Standard, 2 = Express): ");
            string? input = Console.ReadLine();
            try
            {
                int type = Convert.ToInt32(input);
                if (type < 0)
                {
                    Console.WriteLine("Warning: delivery type must be nonnegative (1 or 2).");
                    continue;
                }
                if (type != 1 && type != 2)
                {
                    Console.WriteLine("Warning: delivery type must be 1 (Standard) or 2 (Express).");
                    continue;
                }
                return type;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: input could not be converted to a number. Please enter 1 or 2.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: the number entered is too large. Enter 1 or 2.");
            }
            catch (Exception)
            {
                Console.WriteLine("Error: unexpected error converting the delivery type. Please try again.");
            }
        }
    }

    // Main flow
    decimal weight = ReadWeight();
    int deliveryType = ReadDeliveryType();

    const decimal ratePerPound = 1.50m;
    const decimal rushFee = 15.00m;

    decimal baseCost = Math.Round(weight * ratePerPound, 2);
    decimal total = baseCost;
    if (deliveryType == 2)
    {
        total += rushFee;
    }

    string speedLabel;
    if (deliveryType == 1)
    {
        speedLabel = "Standard";
        Console.WriteLine($"Selected speed: {speedLabel}");
        Console.WriteLine($"Total shipping cost: {total.ToString("C")}\n");
    }
    else
    {
        speedLabel = "Express";
        Console.WriteLine($"Selected speed: {speedLabel}");
        Console.WriteLine($"Total shipping cost: {total.ToString("C")}\n");
    }

    Console.WriteLine("Thank you for using the Shipping Cost Estimator.");

}

// =====================================================
// QUESTION 4 - Utility Bill Tiered Surcharge
// =====================================================
static void Question4()
{
    Console.WriteLine("--- Question 4: Utility Bill Tiered Surcharge ---");


    string input;
    decimal gallons = 0m;
    const decimal baseRate = 0.005m; // $0.005 per gallon
    const decimal surchargeRate = 0.002m; // $0.002 per gallon above threshold
    const decimal threshold = 5000m;

    Console.WriteLine("Monthly Water Bill Calculator");
    bool valid = false;
    do
    {
        Console.Write("Enter monthly water consumption in gallons: ");
        input = Console.ReadLine() ?? string.Empty;
        try
        {
            gallons = Convert.ToDecimal(input);
            if (gallons < 0m)
            {
                Console.WriteLine("Error: Consumption must be nonnegative. Please enter 0 or a positive number.");
            }
            else
            {
                valid = true;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Warning: The entry could not be converted to a number. Please enter digits only (for example: 1234 or 1234.56).");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Warning: The number entered is too large. Please enter a smaller value.");
        }
        catch (Exception)
        {
            Console.WriteLine("Warning: An unexpected error occurred while parsing the input. Please try again.");
        }
    } while (!valid);

    decimal baseBill = gallons * baseRate;
    decimal surcharge = 0m;
    string rateMessage;
    if (gallons > threshold)
    {
        surcharge = (gallons - threshold) * surchargeRate;
        rateMessage = "Tier 2 Surcharge Applied";
    }
    else
    {
        rateMessage = "Standard Rate Applied";
    }

    decimal total = baseBill + surcharge;
    string totalFormatted = total.ToString("C");

    Console.WriteLine($"{rateMessage} — Total: {totalFormatted}");


}
