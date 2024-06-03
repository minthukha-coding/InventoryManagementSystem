
# InventoryManagementSystem

## Overview
InventoryManagementSystem is a software application designed to manage and track inventory levels, orders, sales, and deliveries. The system aims to optimize inventory control and ensure efficient management of stock.

## Features
- **Inventory Tracking**: KeAep track of inventory levels in real-time.
- **Order Management**: Manage purchase and sales orders effectively.
- **Sales Monitoring**: Monitor and record sales transactions.
- **Delivery Management**: Track deliveries to ensure timely arrival.

## Technology Stack
- **Backend**: C#
- **Database**: SQL

## Getting Started

### Prerequisites
- .NET SDK
- SQL Server

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/minthukha-coding/InventoryManagementSystem.git
    ```
2. Navigate to the project directory:
    ```bash
    cd InventoryManagementSystem
    ```
3. Restore the dependencies:
    ```bash
    dotnet restore
    ```
4. Apply the database script:
    ```bash
    sqlcmd -S <YourServerName> -i ims_db_script.sql
    ```
5. Run the application:
    ```bash
    dotnet run
    ```

## Project Structure
- `InventoryManagementSystemApi/DbService`: Contains the database service logic.
- `InventoryManagementSystemApi/Models`: Contains the data models.
- `InventoryManagementSystemApi/Shared`: Contains shared resources and utilities.
- `InventoryManagementSystem.sln`: Solution file for the project.
- `ims_db_script.sql`: SQL script to set up the database.
