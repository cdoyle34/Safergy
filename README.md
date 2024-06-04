Project Overview

This project integrates image recognition features with the Clarifai API, secure user authentication using ASP.NET Core Identity, and a dynamic web interface. Below is a comprehensive overview of the key features and setup.

Features

1. Clarifai API Integration
Functionality: Recognizes food items in images.
Implementation:
The API is called from the application and returns a list of identified food items with confidence scores.
Implemented in ClarifaiService.
Results are displayed on the webpage after an image is uploaded and scanned.
2. Database Setup with PostgreSQL
Setup: PostgreSQL is used as the database.
Configuration:
Installed necessary packages.
Configured the connection string.
Set up the DbContext using Entity Framework Core.
3. ASP.NET Core Identity for Authentication
Functionality:
Registration and login for user accounts with email and password.
Custom user fields, such as Allergens.
Conditional display of login, register, and logout options based on authentication state.
Views:
Registration and login forms.
Dynamic layout reflecting authentication status.
4. User Registration and Login UI
Implementation:
Created views for user registration and login.
Included forms for user credentials and custom fields like Allergens.
5. Logout Functionality
Implementation: Added a logout option for authenticated users.
6. Navigation and Layout Updates
Implementation: Updated application layout to include navigation links that change based on the user's authentication state.
7. Troubleshooting and Configuration
Issues Addressed:
Package installation problems.
Database connection issues.
ASP.NET Core Identity configuration.
Resolved issues with the dotnet-ef tool.
Ensured compatibility with the targeted framework version.
8. Database Migration
Implementation: Performed a database migration to apply the identity schema to PostgreSQL, ensuring correct storage of user accounts and related information.
9. Azure Deployment
Deployment: The project is now deployed on Azure.
Access: The website can be accessed at (https://safergyy.azurewebsites.net)
10. Google Maps API Integration (Work in Progress)
Functionality: Integrating maps functionality with the Google Maps API is currently a work in progress.
Future Updates: More features and enhancements related to maps will be added soon.
