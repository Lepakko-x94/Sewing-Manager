Як інструмент було обрано SonarQube, через його підтримку C#, зручний інтерфейс та швидкість налаштування.

# Лінтинг з SonarQube

Цей документ описує, як запустити SonarQube через Docker для аналізу якості коду.

## Передумови

- Встановлений Docker і Docker Compose.
- Інструмент збірки проєкту (Maven, Gradle, npm тощо).

## Запуск SonarQube через Docker

1. Створіть файл `docker-compose.yml`:

```yaml
version: '3.8'
services:
  sonarqube:
    image: sonarqube:community
    container_name: sonarqube
    depends_on:
      - db
    environment:
      - SONAR_JDBC_URL=jdbc:postgresql://db:5432/sonar
      - SONAR_JDBC_USERNAME=sonar
      - SONAR_JDBC_PASSWORD=sonar
    ports:
      - '9000:9000'
    volumes:
      - sonarqube_data:/opt/sonarqube/data
      - sonarqube_logs:/opt/sonarqube/logs
    networks:
      - sonarnet
  db:
    image: postgres:13
    container_name: sonarqube_db
    environment:
      - POSTGRES_USER=sonar
      - POSTGRES_PASSWORD=sonar
      - POSTGRES_DB=sonar
    volumes:
      - sonarqube_db_data:/var/lib/postgresql/data
    networks:
      - sonarnet
networks:
  sonarnet:
    driver: bridge
volumes:
  sonarqube_data:
  sonarqube_logs:
  sonarqube_db_data:
```

2. Запустіть контейнери:

```bash
docker-compose up -d
```

3. Відкрийте SonarQube: `http://localhost:9000`.

4. Увійдіть (логін: `admin`, пароль: `admin`) і змініть пароль.

## Налаштування проєкту

1. Створіть файл `sonar-project.properties` у корені проєкту:

```properties
sonar.projectKey=my-project-key
sonar.projectName=Мій Проєкт
sonar.sources=src
sonar.host.url=http://localhost:9000
sonar.login=<Ваш-Токен>
```

- Замініть `<Ваш-Токен>` на токен із SonarQube (`Account > Security`).

2. Встановіть SonarQube Scanner CLI та додайте до PATH.

3. Запустіть аналіз:

```bash
sonar-scanner
```

## Перегляд результатів

- У браузері: Відкрийте `http://localhost:9000` для звітів.
- У IDE: Встановіть плагін SonarQube для IDE (SonarLint) для миттєвого аналізу.

## Корисні команди

- Переглянути логи:

```bash
docker logs sonarqube
```

- Зупинити контейнери:

```bash
docker-compose down
```