# BACK

sentencias SQL para crear tablas se encuentrar en el archivo crear_tablas.sql

# ACCESO A SQL SERVER

configurar las credenciales de acceso a sql server en el archivo CreateStudentController..cs

            builder.DataSource = "<your_server>.database.windows.net";
            builder.UserID = "<your_username>";
            builder.Password = "<your_password>";
            builder.InitialCatalog = "<your_database>";
