# Stage 1: Build Angular app
FROM node:20 AS build
WORKDIR /app

COPY package*.json ./
RUN npm install

COPY . .
RUN npm run build

# Stage 2: Serve with Nginx
FROM nginx:alpine
WORKDIR /usr/share/nginx/html
RUN rm -rf ./*

# Copy Angular build (check path!)
COPY --from=build /app/dist/todo-ui/browser /usr/share/nginx/html

ENV PORT=8080

EXPOSE 8080
CMD ["nginx", "-g", "daemon off;"]