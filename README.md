<h2>A decentralized library application</h2>

The architecture of the application consists of 3 local libraries for borrowing books and one central library for user account management.
Postgres database was used for data storage. 
The application is deployed both using Docker Compose and as Kubernetes cluster.
In order to automate the process of publishing the Docker images to DockerHub, a GitHub workflow was set up to trigger each time a commit is pushed.
