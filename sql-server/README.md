# Deploying Microsoft SQL Server

A couple things:

- This is not secure, or hardened, or anything like that - it is intended to give you a dev environment with SQL Server to use for doing development.
- It uses the default storage class, which means the data will be blown away when you shut down your cluster.

This is not meant to be an example of how to deploy a stateful service (like SQL Server) into a cluster for production.

## Create or Choose a Namespace for This

Usually I just put it in the same namespace as my appliction.

```
kubectl create namespace hypertheory
```

Switch to it:

```
kubectl config set-context --current --namespace=hypertheory
```

Apply the deployments:

- I like to do the PVC first. It shouldn't matter, but with Rancher Desktop sometimes it freaks out if some deployment makes a claim on it before it is created.

In this folder:

```
kubectl apply -f .\pvc.yaml
```

Then the deployment and service:

```
kubectl apply -f .\deployment.yaml
kubectl apply -f .\service.yaml
```

## Using this Outside the Cluster for Development Work

You can _port-forward_ the service temporarily while you do development work.

We will map port 1433 (SQL Server, inside the cluster) to port 1533 outside the cluster.

In a new terminal window (that you can leave running while you work):

```
kubectl port-forward services/mssql-service 1533:1433 -n hypertheory
```

To Connect using Visual Studio SQL Server Explorer Window or other tools:

- server: 127.0.0.1,1533
- Use SQL Server Authentication
  - Username: SA
  - Password: TokyoJoe138!
