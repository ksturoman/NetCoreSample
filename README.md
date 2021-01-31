You need to install [PostgreSQL server](https://www.postgresql.org/download/) on your computer. Expected configuration is localhost:5432 host, database and username are 'postgres', password is 'admin'.

After you launch the application you can test API with Swagger UI it will be opened automatically in your browser. Call for POST JobTask method to create a new task. You will receive its Id - copy it.

```json
{
  "id": "101c4d75-e6a7-44c3-be6f-c8005c04c41c"
}
```

Then call for GET/{id} method using Id above. This task has been launched at the end of the previous method and now it has 'Running' status.

```json
{
  "status": "Running",
  "timestamp": "2021-01-31T21:18:27.5075170+03:00"
}
```

After 2 minutes call that method again. Now task should be 'Finished'.

```json
{
  "status": "Finished",
  "timestamp": "2021-01-31T21:20:27.5261890+03:00"
}
```
