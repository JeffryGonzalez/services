# NGINX Ingress

> Note: If you are using Rancher Dekstop, it's probably best if you remove the `traefik` ingress first.

## Removing Traefik and Traefik-CRD

We will remove these since we are going to install the NGINX Ingress.

```
kubectl config set-context --current --namespace=kube-system
```

Then:

```
helm uninstall traefik-crd
helm uninstall traefik
```

## Create a New Namespace for Your Ingress Controller

```
kubectl create namespace ingress-nginx
kubectl config set-context --current --namespace=ingress-nginx
```

## Add Your Ingress Controller


Add the Helm repo for bitnami
```
helm repo add bitnami https://charts.bitnami.com/bitnami
```


```
helm install ingress bitnami/nginx-ingress-controller
```

> Note: The default install does not support TLS.

Check to see if the pods started:

```
kubectl get pods
```

Should show some output like this:

```
NAME                                                              READY   STATUS    RESTARTS   AGE
svclb-ingress-nginx-ingress-controller-jvlxn                      2/2     Running   0          74s
ingress-nginx-ingress-controller-default-backend-78586699f7sl2k   1/1     Running   0          74s
ingress-nginx-ingress-controller-777bd948d7-4pwd8                 1/1     Running   0          74s
```
