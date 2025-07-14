-- Скрипт удаления всех данных из таблиц в правильном порядке с учётом внешних ключей

-- Удаляем данные из таблиц, которые зависят от других (детей) — сначала "самые вложенные"

DELETE FROM Supplements_Reviews;
DELETE FROM NewConsumptions;
DELETE FROM Nutrients_Supplements;
DELETE FROM SetNutrients;
DELETE FROM Foods_Nutrients;
DELETE FROM Reviews;
DELETE FROM CurrentDailyConsumptions;
DELETE FROM Assessments;

-- Затем удаляем данные из таблиц, от которых зависят предыдущие данные

DELETE FROM Supplements;
DELETE FROM Nutrients;
DELETE FROM Foods;
DELETE FROM PhysicalActivityLevels;
DELETE FROM Users;
