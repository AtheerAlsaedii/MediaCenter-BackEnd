
##Photo and Video Library API
This API allows you to manage and display photos and videos. Built with ASP.NET Core, it offers endpoints for users to browse photos and videos, and for admins to add new content. The application uses Entity Framework Core for database management and 
PostgreSQL for the database.
- Features
Photo Management: Users can browse photos. Admins can add new photos.
Video Management: Users can browse videos. Admins can add new videos.
Technologies
ASP.NET Core: Framework for building the web API.
C#: Language used for server-side logic.
Entity Framework Core: ORM for data management.
PostgreSQL Server: Database for storing metadata.

- Project Structure
Models: Defines data structures for photos and videos.
Data: Configures Entity Framework Core for database operations.
Controllers: Handles API requests for photo and video management.
Services: Implements business logic and data interactions.
Configuration: Manages application settings and database connections.
