FROM sql 16.0.1
EXPOSE 7276
COPY ./RestWithASPNET5/db/migrations/ /home/database/
COPY ./RestWithASPNET5/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh/