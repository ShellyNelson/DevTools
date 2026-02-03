# AWS Deployment Guide

This guide covers multiple ways to host your Node.js Hello World website on AWS.

## Option 1: AWS Elastic Beanstalk (Easiest - Recommended for Beginners)

Elastic Beanstalk automatically handles infrastructure, load balancing, and scaling.

### Steps:

1. **Install AWS CLI** (if not already installed):
   ```bash
   # Download from: https://aws.amazon.com/cli/
   ```

2. **Install EB CLI**:
   ```bash
   pip install awsebcli
   ```

3. **Initialize Elastic Beanstalk**:
   ```bash
   eb init
   ```
   - Select your region
   - Choose Node.js platform
   - Select Node.js version

4. **Create and deploy**:
   ```bash
   eb create hello-world-env
   eb open
   ```

5. **Update your app** (for future deployments):
   ```bash
   eb deploy
   ```

### Required Files:
- ✅ `package.json` (already exists)
- ✅ `server.js` (already exists)
- ✅ `.ebextensions/` (optional, for custom config)

**Pros:** Easy, automatic scaling, handles infrastructure
**Cons:** Slightly more expensive than EC2

---

## Option 2: AWS EC2 (Most Control)

Deploy on a virtual server with full control.

### Steps:

1. **Launch an EC2 instance**:
   - Go to AWS Console → EC2
   - Launch Instance
   - Choose Ubuntu Server (free tier eligible)
   - Configure security group: Allow HTTP (port 80) and HTTPS (port 443)

2. **Connect via SSH**:
   ```bash
   ssh -i your-key.pem ubuntu@your-ec2-ip
   ```

3. **Install Node.js**:
   ```bash
   curl -fsSL https://deb.nodesource.com/setup_18.x | sudo -E bash -
   sudo apt-get install -y nodejs
   ```

4. **Deploy your app**:
   ```bash
   # Clone or upload your code
   git clone your-repo-url
   cd hello-world-website
   npm install
   ```

5. **Use PM2 to keep server running**:
   ```bash
   sudo npm install -g pm2
   pm2 start server.js
   pm2 startup
   pm2 save
   ```

6. **Set up Nginx as reverse proxy** (optional but recommended):
   ```bash
   sudo apt-get install nginx
   # Configure nginx to proxy to localhost:3000
   ```

**Pros:** Full control, cost-effective, flexible
**Cons:** Requires server management knowledge

---

## Option 3: AWS Lambda + API Gateway (Serverless)

Convert to serverless function - pay only for requests.

### Steps:

1. **Install Serverless Framework**:
   ```bash
   npm install -g serverless
   ```

2. **Use the `serverless.yml` configuration** (see below)

3. **Deploy**:
   ```bash
   serverless deploy
   ```

**Pros:** Pay per request, auto-scaling, no server management
**Cons:** Cold starts, 15-minute timeout limit

---

## Option 4: AWS App Runner (Modern & Simple)

Container-based deployment with minimal configuration.

### Steps:

1. **Push code to GitHub/GitLab/Bitbucket**

2. **Create App Runner service**:
   - Go to AWS Console → App Runner
   - Create service
   - Connect to your repository
   - Configure build: `npm install && npm start`
   - Set port: 3000

3. **Deploy automatically** on git push

**Pros:** Simple, automatic deployments, managed service
**Cons:** Slightly more expensive

---

## Option 5: AWS Lightsail (Simplified VPS)

Simplified version of EC2 with fixed pricing.

### Steps:

1. **Create Lightsail instance**:
   - Go to AWS Console → Lightsail
   - Create Node.js instance
   - Choose your plan

2. **Deploy via SSH** (similar to EC2)

**Pros:** Simple, predictable pricing, good for small apps
**Cons:** Less flexible than EC2

---

## General Requirements for All Options

1. **AWS Account**: Sign up at https://aws.amazon.com
2. **IAM User**: Create user with appropriate permissions
3. **Security**: Configure security groups/firewalls
4. **Domain (Optional)**: Use Route 53 for custom domain

## Environment Variables

Your code already uses `process.env.PORT`, which is perfect for AWS. You can set additional environment variables in:
- Elastic Beanstalk: Environment configuration
- EC2: `.env` file or system environment
- Lambda: Function configuration

## Cost Estimates (Approximate)

- **Elastic Beanstalk**: ~$15-30/month (includes EC2)
- **EC2 t2.micro**: ~$10/month (free tier eligible for 12 months)
- **Lambda**: ~$0.20 per million requests (very cheap for low traffic)
- **App Runner**: ~$7-15/month
- **Lightsail**: ~$3.50-10/month

## Recommended for Your App

For a simple Hello World app, I recommend:
1. **Lambda + API Gateway** (if you want serverless)
2. **EC2 t2.micro** (if you want traditional hosting, free tier eligible)
3. **Elastic Beanstalk** (if you want easiest deployment)

