# BankingApp
BankApp is an advanced banking software solution that provides a robust and secure platform for managing bank accounts, performing transactions, and handling user roles. The application offers features designed to provide both regular users and administrators with distinct access privileges, enabling efficient banking operations.

Features:
Account Management: Users can view their accounts, select accounts for transactions, and monitor their balances.

Fund Transfers: The application allows users to send money between accounts, ensuring the same currency is used, and checks that the sender has sufficient balance.

Currency Exchange: BankApp supports currency conversion, allowing users to transfer funds between accounts with different currencies, and it automatically handles the conversion based on current exchange rates.

CRUD Operations: The application supports Create, Read, Update, and Delete operations for managing users, accounts, transactions, and currency exchange rates.

User Roles: There are two primary user roles:

Admin: Has the ability to manage accounts, view all transactions, update user information, and perform CRUD operations.

User: Can only view their own accounts, perform transactions with their own funds, and request currency exchange.

Transaction Management: Supports real-time transfer of funds between user accounts, with validation for currency compatibility, sufficient balance, and automatic handling of exchange rates for cross-currency transactions.

Online Programming: The application is designed to handle online scheduling and transaction processing in a secure, real-time environment.

Technologies Used:
C# and Windows Forms for application development.

SQL Server for data storage and transaction management.

Role-Based Authentication for managing different user levels (Admin, User).

Currency Conversion Logic integrated into transaction processing.
