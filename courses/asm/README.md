# Angular State Management

There is a single service we will use. The **PlaylistsApi**. It will be available at `http://api.hypertheory-class.com/asm/v1`.

## Create a Namespace for our Application

```
kubectl create namespace hypertheory:
```

Switch to that namespace:

```
kubectl config set-context --current --namespace=hypertheory
```

## SQL Server

This API needs a development SQL Server Database. Do the instructions for sql-server in the root of this repo.

## Deploy This Application

We will deploy the files in the `courses\asm\playlists` folder.

```
kubectl apply -f .
```
