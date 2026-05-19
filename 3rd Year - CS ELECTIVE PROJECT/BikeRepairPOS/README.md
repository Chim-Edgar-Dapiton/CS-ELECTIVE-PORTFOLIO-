# Bike Repair Shop POS System

A complete **Windows Forms C# application** (.NET Framework) for managing bike repair services with point-of-sale functionality.

## Features ✅

- **Customer Management**: Input customer names
- **Bike Type Selection**: Choose from Mountain, Road, City, or BMX
- **6 Service Options**:
  - Tire Repair ($15)
  - Chain Replacement ($25)
  - Brake Pads ($35)
  - Spoke Repair ($12)
  - Wheel Alignment ($20)
  - Gear Adjustment ($18)
- **Auto-Calculation**: Real-time total price calculation
- **Repair Completion**: Add completed repairs to history with timestamp
- **Repair History**: ListBox with all completed repairs
- **Clear Functionality**: Reset all fields for next customer
- **Sample Data**: Pre-loaded with 5 sample repair records

## System Requirements

- Windows OS (7 or later)
- .NET Framework 4.7.2

## Build & Run

### Using Visual Studio
1. Open `BikeRepairPOS.csproj` in Visual Studio
2. Press **F5** to run

### Using Command Line
```bash
cd BikeRepairPOS
msbuild BikeRepairPOS.csproj
bin\Debug\BikeRepairPOS.exe
```

## How to Run (Easy Methods)

### **🚀 Double-Click Method (Simplest!)**
1. Go to `f:\Project Elective\`
2. **Double-click** `RunBikeRepairPOS.bat`
3. App opens instantly - no command prompt!

### **PowerShell Script Method**
1. Go to `f:\Project Elective\`
2. **Double-click** `RunBikeRepairPOS.ps1`
3. App opens instantly

### **Command Line Method**
```powershell
cd "f:\Project Elective\BikeRepairPOS"
.\bin\Debug\BikeRepairPOS.exe
```

### **Using VS Code**
1. Open folder in VS Code
2. Press **F5** to debug/run

## How to Use

1. **Enter Customer Name** in the textbox
2. **Select Bike Type** from dropdown
3. **Check Services** needed for repair
4. **View Total** - automatically calculated
5. **Click "Complete Repair"** to add to history
6. **Click "Clear"** to reset for next customer
7. **View History** on the right panel

## Project Structure

```
BikeRepairPOS/
├── BikeRepairPOS.csproj       # Project file
├── Form1.cs                    # Main form with all controls
├── Program.cs                  # Application entry point
├── app.config                  # Configuration
└── Properties/
    └── AssemblyInfo.cs         # Assembly information
```

## Notes

- ✅ No external libraries needed
- ✅ No database required
- ✅ All controls created programmatically (drag-drop ready)
- ✅ Professional business app design
- ✅ Copy-paste ready code
- ✅ Beginner-friendly

## Author
School Project - 2026

---
**Ready to use! Just compile and run!** 🚴
