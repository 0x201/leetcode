package leetcode

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestRandomizedSet(t *testing.T) {
	randomizedSet := RandomizedSetConstructor()
	assert.True(t, randomizedSet.Insert(1))
	assert.False(t, randomizedSet.Remove(2))
	assert.True(t, randomizedSet.Insert(2))
	assert.Contains(t, []int{1, 2}, randomizedSet.GetRandom())
	assert.True(t, randomizedSet.Remove(1))
	assert.False(t, randomizedSet.Insert(2))
	assert.Equal(t, 2, randomizedSet.GetRandom())
}
