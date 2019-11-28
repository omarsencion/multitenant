namespace Example.Library.DataStores.MySql
{
    public static class MySqlExampleDataStoreSql
    {
        public const string GET_USER_SQL = @"
SELECT
    *
FROM
    users.userInfo AS u
    LEFT JOIN contacts.contactInfo AS c ON c.UserId = u.Id
WHERE
    id = @id;";

        public const string CREATE_USER_SQL = @"
INSERT INTO users.userInfo (
    Name,
    Credits,
    Created,
    Enabled,
    UserTypeId,
    Expires,
    UserLevel
)
VALUES (
    @Name,
    @Credits,
    @Created,
    @Enabled,
    @UserTypeId,
    @Expires,
    @UserLevel
);
SELECT LAST_INSERT_ID();";

        public const string UPDATE_USER_SQL = @"
UPDATE
    users.userInfo
SET
    Name = @Name,
    Credits = @Credits,
    Created = @Created,
    Enabled = @Enabled,
    UserTypeId = @UserTypeId,
    Expires = @Expires,
    UserLevel = @UserLevel
WHERE
    id = @id;
SELECT ROW_COUNT();";

        public const string DELETE_USER_SQL = @"
DELETE FROM
    users.userInfo
WHERE
    id = @id;
SELECT ROW_COUNT();";
    }
}