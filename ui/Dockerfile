# Stage 1: Build Angular app
FROM node:20 AS build
WORKDIR /app

COPY package*.json ./
RUN npm install

COPY . .
RUN npm run build -- --output-path=dist --configuration production

# Stage 2: Serve with Nginx
FROM nginx:alpine
WORKDIR /usr/share/nginx/html
RUN rm -rf ./*

# Copy Angular build (check path!)
COPY --from=build /app/dist/todo-ui/browser /usr/share/nginx/html

# Ensure readable permissions
RUN chown -R root:root /usr/share/nginx/html && chmod -R 755 /usr/share/nginx/html

# Copy custom Nginx config
COPY default.conf /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]