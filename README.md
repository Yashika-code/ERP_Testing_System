# ERP Testing System

## Overview
The **ERP Testing System** is a C#.NET WinForms application designed to simulate an ERP-style frontend for managing master data, testing inputs, and visualizing results. This project provides a clean and functional interface to perform CRUD operations, auto-calculation, chart visualization, and CSV/Excel export.

---

## Features

### Master Modules (CRUD)
- **Part Code Master**: Part Code, Item Description, Ratio, Class, VA, Label Type, Created Date/Time, Username  
- **Party Master**: Party Name, Contact Person, Email, Address, Created Date/Time, Username  
- **IEC Standard Master**: IEC Standard, Created Date/Time, Username  
- **Model Master**: Model Name, Ratio, Class, VA, Phase, Created Date/Time, Username  
- **Class Master**: Class Name, Created Date/Time, Username  
- **VA Master**: VA Name, Created Date/Time, Username  
- **Label Master**: Label Type, Label Link, Created Date/Time, Username  

---

### Testing Screen
- **Top Inputs**: Port Name, Amber, CT/PT, Part Code, Company, Phase, Ratio, Jobcard No, Sec, Points, PO No, Invoice No, Serial No, JC Qty, Partial Qty, IEC Standard, Model, FS, kV, IL  
- **Right Panel Inputs**: Revision No & Date, Prefix (Checkbox + TextBox), Auto Printing (Checkbox), VF, HSV  
- **Buttons**: Save, New, Print, Export to Excel  
- **Sidebar Menu**: Test, Pending JC, Report, Admin Panel (placeholder), JC Manipulation (placeholder), Label Master, Range Master  

---

### Data Grid
- Columns: Sr.No, BD %, Pri.Vol %, Excitation %, Ratio Error %, Phase Error (MIN), Class, Status  
- Supports live auto-calculation and chart visualization.

---

### Auto Calculation
- **Quantity = Points × Set**  
- Updates instantly in the grid when inputs change  
- Empty or invalid fields are treated as 0

---

### Chart Visualization
- Column chart shows **BD %** values from the grid  
- Updates dynamically with grid changes

---

### Export Functionality
- Export grid data to CSV/Excel using **Export to Excel** button

---

### Placeholder Buttons
- **Admin Panel** and **JC Manipulation** show placeholder messages since assignment does not require functional logic

---

## Technical Details
- **Framework:** .NET 8.0 (Windows)  
- **Language:** C#  
- **UI:** WinForms  
- **Charting:** `WinForms.DataVisualization` v1.10.0  
- **Data Handling:** In-memory lists  
- **Validation:** Numeric and mandatory field validation implemented

---

## Project Structure
```

ERP_Testing_System/
│   ERP_Testing_System.csproj
│   Program.cs
│   README.md
├─ Forms/
│   ├─ MainForm.cs
│   ├─ TestingForm.cs
│   ├─ PartCodeMasterForm.cs
│   └─ ... (other master forms)
├─ Models/
│   ├─ BaseEntity.cs
│   ├─ PartCode.cs
│   ├─ Party.cs
│   └─ ... (other models)
├─ Data/
│   └─ InMemoryDatabase.cs

````

---

## How to Run
```powershell
cd ERP_Testing_System
dotnet restore
dotnet run
````

* MainForm opens → navigate to **Testing Screen**
* Enter data in inputs and grid
* Observe **auto-calculation** and **chart updates**
* Use **Export to Excel** to save data

---

## Sample Data

| Points | Set | BD % | Pri.Vol % | Excitation % | Ratio Error % | Phase Error | Class | Status |
| ------ | --- | ---- | --------- | ------------ | ------------- | ----------- | ----- | ------ |
| 10     | 2   | 90   | 95        | 80           | 5             | 1           | A     | OK     |
| 5      | 3   | 85   | 90        | 75           | 6             | 2           | B     | Fail   |

---

## Future Improvements

* Implement full Admin Panel and JC Manipulation functionality
* Integrate SQLite or SQL Express for persistent storage
* Add search/filter features in masters and grid
* Add Dark/Light mode toggle
* Audit logs (CreatedBy / ModifiedBy)

---

## Author

* Developed by: Yashika
* Date: December 2025
* Purpose: Internship assignment submission for ERP Testing System
