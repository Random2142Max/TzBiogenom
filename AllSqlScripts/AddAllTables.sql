-- Таблица Users
CREATE TABLE Users (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(20) NOT NULL,
    Genre BOOLEAN NOT NULL,
    DateBirth DATE NOT NULL,
    Height INT NOT NULL,
    Weight NUMERIC(4,2) NOT NULL,
    Email VARCHAR(40) NOT NULL,
    PhoneNumber VARCHAR(16) NULL,
    PromoCode VARCHAR(40),
    ConfirmationCode INT
);

-- Таблица Foods
CREATE TABLE Foods (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    QuantityPerDay INT NULL,
    StandardDivisions VARCHAR(25) NOT NULL,
    UnitOfMeasurement VARCHAR(5) NOT NULL,
    TypeOfFoodSection SMALLINT NOT NULL
);

-- Таблица Nutrients
CREATE TABLE Nutrients (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    ImportanceForHealth TEXT,
    ManifestationOfDeficit TEXT,
    Prevention TEXT,
    ConsumptionRecommendations TEXT
);

-- Таблица Foods_Nutrients (связь многие-ко-многим между Foods и Nutrients)
CREATE TABLE Foods_Nutrients (
    Id SERIAL PRIMARY KEY,
    CountNutrients NUMERIC(8,2) NOT NULL,
    UnitOfMeasurementNutrients VARCHAR(5) NOT NULL,
    Id_Nutrients INT NOT NULL,
    Id_Foods INT NOT NULL,
    CONSTRAINT fk_foods_nutrients_nutrients FOREIGN KEY (Id_Nutrients) REFERENCES Nutrients(Id)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT fk_foods_nutrients_foods FOREIGN KEY (Id_Foods) REFERENCES Foods(Id)
        ON DELETE CASCADE ON UPDATE CASCADE
);

-- Таблица PhysicalActivityLevels
CREATE TABLE PhysicalActivityLevels (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Description VARCHAR(100)
);

-- Таблица SetNutrients (связь с Foods_Nutrients и PhysicalActivityLevels)
CREATE TABLE SetNutrients (
    Id SERIAL PRIMARY KEY,
    PhysicalActivityLevel INT NOT NULL,
    HighLimitNorm NUMERIC(8,2) NOT NULL,
    LowerLimitNorm NUMERIC(8,2) NOT NULL,
    Id_Foods_Nutrients INT NOT NULL,
    Id_PhysicalActivityLevels INT NOT NULL,
    CONSTRAINT fk_setnutrients_foods_nutrients FOREIGN KEY (Id_Foods_Nutrients) REFERENCES Foods_Nutrients(Id)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT fk_setnutrients_physicalactivitylevels FOREIGN KEY (Id_PhysicalActivityLevels) REFERENCES PhysicalActivityLevels(Id)
        ON DELETE CASCADE ON UPDATE CASCADE
);

-- Таблица Assessments
CREATE TABLE Assessments (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    DateTimeOfStart TIMESTAMP NOT NULL,
    IsEnd BOOLEAN NOT NULL,
    Id_Users INT NOT NULL,
    CONSTRAINT fk_assessments_users FOREIGN KEY (Id_Users) REFERENCES Users(Id)
        ON DELETE CASCADE ON UPDATE CASCADE
);

-- Таблица CurrentDailyConsumptions
CREATE TABLE CurrentDailyConsumptions (
    Id SERIAL PRIMARY KEY,
    DateTimeOfFilling TIMESTAMP NOT NULL,
    Id_Assessments INT NOT NULL,
    CONSTRAINT fk_currentdailyconsumptions_assessments FOREIGN KEY (Id_Assessments) REFERENCES Assessments(Id)
        ON DELETE CASCADE ON UPDATE CASCADE
);

-- Таблица Reviews
CREATE TABLE Reviews (
    Id SERIAL PRIMARY KEY,
    Text TEXT NOT NULL,
    DateTime DATE NOT NULL,
    Id_Users INT NOT NULL,
    CONSTRAINT fk_reviews_users FOREIGN KEY (Id_Users) REFERENCES Users(Id)
        ON DELETE CASCADE ON UPDATE CASCADE
);

-- Таблица Supplements
CREATE TABLE Supplements (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    CountNutrients NUMERIC(8,2) NOT NULL,
    UnitOfMeasurementNutrients VARCHAR(5) NOT NULL,
    Description TEXT,
    Application TEXT
);

-- Таблица Supplements_Reviews (связь многие-ко-многим между Supplements и Reviews)
CREATE TABLE Supplements_Reviews (
    Id SERIAL PRIMARY KEY,
    Id_Supplements INT NOT NULL,
    Id_Reviews INT NOT NULL,
    CONSTRAINT fk_supplements_reviews_supplements FOREIGN KEY (Id_Supplements) REFERENCES Supplements(Id)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT fk_supplements_reviews_reviews FOREIGN KEY (Id_Reviews) REFERENCES Reviews(Id)
        ON DELETE CASCADE ON UPDATE CASCADE
);

-- Таблица Nutrients_Supplements (связь многие-ко-многим между Nutrients и Supplements)
CREATE TABLE Nutrients_Supplements (
    Id SERIAL PRIMARY KEY,
    Id_Nutrients INT NOT NULL,
    Id_Supplements INT NOT NULL,
    CONSTRAINT fk_nutrients_supplements_nutrients FOREIGN KEY (Id_Nutrients) REFERENCES Nutrients(Id)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT fk_nutrients_supplements_supplements FOREIGN KEY (Id_Supplements) REFERENCES Supplements(Id)
        ON DELETE CASCADE ON UPDATE CASCADE
);

-- Таблица CurrentDailyConsumptions и Nutrients_Supplements связаны через NewConsumptions
CREATE TABLE NewConsumptions (
    Id SERIAL PRIMARY KEY,
    Id_CurrentDailyConsumptions INT NOT NULL,
    Id_Nutrients_Supplements INT NOT NULL,
    CONSTRAINT fk_newconsumptions_currentdailyconsumptions FOREIGN KEY (Id_CurrentDailyConsumptions) REFERENCES CurrentDailyConsumptions(Id)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT fk_newconsumptions_nutrients_supplements FOREIGN KEY (Id_Nutrients_Supplements) REFERENCES Nutrients_Supplements(Id)
        ON DELETE CASCADE ON UPDATE CASCADE
);