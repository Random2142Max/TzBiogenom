-- Скрипт удаления всех таблиц с учётом зависимостей

-- Удаляем таблицы в порядке от зависимых к независимым, чтобы избежать ошибок FK

DROP TABLE IF EXISTS Supplements_Reviews CASCADE;
DROP TABLE IF EXISTS NewConsumptions CASCADE;
DROP TABLE IF EXISTS Nutrients_Supplements CASCADE;
DROP TABLE IF EXISTS SetNutrients CASCADE;
DROP TABLE IF EXISTS Foods_Nutrients CASCADE;
DROP TABLE IF EXISTS Reviews CASCADE;
DROP TABLE IF EXISTS CurrentDailyConsumptions CASCADE;
DROP TABLE IF EXISTS Assessments CASCADE;

DROP TABLE IF EXISTS Supplements CASCADE;
DROP TABLE IF EXISTS Nutrients CASCADE;
DROP TABLE IF EXISTS Foods CASCADE;
DROP TABLE IF EXISTS PhysicalActivityLevels CASCADE;
DROP TABLE IF EXISTS Users CASCADE;