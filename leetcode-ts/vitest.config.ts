import { defineConfig } from 'vitest/config'

export default defineConfig({
    test: {
        coverage: {
            provider: 'v8', // v8 or istanbul
            reporter: ['html-spa']
        },
        exclude: [
            '**/node_modules/**',
            '**/dist/**',
        ],
        include: [
            './test/**/*.test.ts'
        ]
    },
})