-- Вставка данных в таблицу Users
INSERT INTO Users (Name, Genre, DateBirth, Height, Weight, Email, PhoneNumber, PromoCode, ConfirmationCode)
 VALUES
    ('Иван', TRUE, '1985-07-10', 180, 75.50, 'ivan@yandex.ru', '+79991234567', 'PROMO10', 4556),
    ('Мария', FALSE, '1990-05-22', 165, 60.00, 'maria@example.com', '+79997654321', NULL, 8798);
    
-- Вставка данных в таблицу Foods
INSERT INTO Foods (Name, QuantityPerDay, StandardDivisions, UnitOfMeasurement, TypeOfFoodSection)
 VALUES
    ('Пиво', NULL, '200,300,500', 'мл', 1),
    ('Молоко', NULL, '200,300,500', 'мл', 2),
    ('Безалкогольные напитки', NULL, '200,300,500', 'мл', 3);
    
-- Вставка данных в таблицу Nutrients
INSERT INTO Nutrients (Name, ImportanceForHealth, ManifestationOfDeficit, Prevention, ConsumptionRecommendations)
 VALUES
    ('Витамин D (кальциферол)', '', '', '', ''),
    ('Витамин A', '', '', '', ''),
    ('Алкоголь (спирт)', '', '', '', '');
    
-- Вставка данных в таблицу Foods_Nutrients
INSERT INTO Foods_Nutrients (CountNutrients, UnitOfMeasurementNutrients, Id_Nutrients, Id_Foods)
 VALUES
    (5.0, 'мг', 1, 1),
    (20.0, 'мг', 2, 2),
    (10.0, 'мг', 3, 3);
    
-- Вставка данных в таблицу PhysicalActivityLevels
INSERT INTO PhysicalActivityLevels (Name, Description)
 VALUES
    ('Низкий', 'Малоподвижный образ жизни'),
    ('Средний', 'Умеренная активность'),
    ('Высокий', 'Интенсивные физические нагрузки');
    
-- Вставка данных в таблицу SetNutrients
INSERT INTO SetNutrients (PhysicalActivityLevel, HighLimitNorm, LowerLimitNorm, Id_Foods_Nutrients, Id_PhysicalActivityLevels)
 VALUES
    (1, 100.0, 50.0, 1, 1),
    (2, 150.0, 75.0, 2, 2),
    (3, 200.0, 100.0, 3, 3);
    
-- Вставка данных в таблицу Assessments
INSERT INTO Assessments (Name, DateTimeOfStart, IsEnd, Id_Users)
 VALUES
    ('Оценка качества питания (краткая)', '2025-07-01 08:00:00', FALSE, 1),
    ('Оценка качества питания (подробная)', '2025-07-05 09:30:00', TRUE, 2);

-- Вставка данных в таблицу CurrentDailyConsumptions
INSERT INTO CurrentDailyConsumptions (DateTimeOfFilling, Id_Assessments)
 VALUES
    ('2025-07-01 12:00:00', 1),
    ('2025-07-05 13:00:00', 2);
    
-- Вставка данных в таблицу Reviews
INSERT INTO Reviews (Text, DateTime, Id_Users)
 VALUES
    ('Отличный продукт, помогает!', '2025-07-02', 1),
    ('Хорошее качество, рекомендую.', '2025-07-06', 2);
    
-- Вставка данных в таблицу Supplements
INSERT INTO Supplements (Name, CountNutrients, UnitOfMeasurementNutrients, Description, Application)
 VALUES
    ('Витамин C таблетки', 500.0, 'мг', 'Таблетки для повышения иммунитета', 'Принимать 1 раз в день'),
    ('Кальций капсулы', 600.0, 'мг', 'Капсулы для здоровья костей', 'Принимать после еды'),
    ('Железо сироп', 300.0, 'мг', 'Сироп для лечения анемии', 'Принимать 2 раза в день');
    
-- Вставка данных в таблицу Supplements_Reviews
INSERT INTO Supplements_Reviews (Id_Supplements, Id_Reviews)
 VALUES
    (1, 1),
    (2, 2);
    
-- Вставка данных в таблицу Nutrients_Supplements
INSERT INTO Nutrients_Supplements (Id_Nutrients, Id_Supplements)
 VALUES
    (1, 1),
    (2, 2),
    (3, 3);
    
-- Вставка данных в таблицу NewConsumptions
INSERT INTO NewConsumptions (Id_CurrentDailyConsumptions, Id_Nutrients_Supplements)
 VALUES
    (1, 1),
    (2, 2);