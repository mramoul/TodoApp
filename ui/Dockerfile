# Stage 1: Build Angular app
FROM node:20 AS build
WORKDIR /app

# Copy package.json first
COPY package*.json ./
RUN npm install

# Copy all sources
COPY . .

# Build Angular for production
RUN npm run build -- --output-path=dist/todo-ui/browser --configuration production


# Stage 2: Serve with Nginx
FROM nginx:alpine
WORKDIR /usr/share/nginx/html
RUN rm -rf ./*

COPY --from=build /app/dist/todo-ui/browser /usr/share/nginx/html

COPY default.conf /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
