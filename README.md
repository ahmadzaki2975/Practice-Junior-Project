# Practice-Junior-Project
 
## SQL Procedures
#### 1. Register User
```
CREATE OR REPLACE FUNCTION register_user(
    in_username text,
    in_password text
)
RETURNS integer AS $$
BEGIN
    IF EXISTS (
        SELECT 1
        FROM users
        WHERE username = in_username
    ) THEN
        RETURN 409; -- Conflict
    ELSE
        INSERT INTO users (username, password)
        VALUES (in_username, in_password);
        RETURN 201; -- Created
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        RETURN 500; -- Internal Server Error
END;
$$ LANGUAGE plpgsql;
```
#### 2. Login User
```
CREATE OR REPLACE FUNCTION login_user(
    in_username text,
    in_password text
)
RETURNS integer AS $$
BEGIN
    IF EXISTS (
        SELECT 1
        FROM users
        WHERE username = in_username AND password = in_password
    ) THEN
        RETURN 200; -- Login successful
    ELSE
        RETURN 401; -- Wrong username or password
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        RETURN 500; -- Internal Server Error
END;
$$ LANGUAGE plpgsql;
```
