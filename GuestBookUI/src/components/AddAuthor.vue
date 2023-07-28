<template>
  <div class="q-pa-md">
    <q-card class="q-pa-xl">
      <q-form @submit.prevent="addAuthor">
        <div class="form-group">
          <q-input
            type="text"
            hint="First Name should be less than 50 characters length"
            maxlength="50"
            counter
            stack-label
            label="First Name"
            v-model="firstName"
            :rules="firstNameRules"
            autogrow
            clearable
          />
        </div>

        <div class="form-group">
          <q-input
            type="text"
            hint="Last Name should be less than 50 characters length"
            maxlength="50"
            counter
            stack-label
            label="Last Name"
            v-model="lastName"
            :rules="lastNameRules"
            autogrow
            clearable
          />
        </div>

        <div class="form-group">
          <q-input
            type="text"
            hint="Email should be less than 100 characters length"
            maxlength="100"
            stack-label
            label="Email"
            v-model="email"
            counter
            autogrow
            clearable
          />
        </div>

        <div class="form-group">
          <q-input
            type="text"
            hint="Phone should be less than 13 characters length"
            maxlength="13"
            stack-label
            label="Phone"
            v-model="phone"
            autogrow
            clearable
          />
        </div>

        <div>
          <q-btn :disabled="hasActiveErrors" label="Submit" type="submit" color="primary" />
          <q-btn label="Reset" type="reset" color="primary" flat class="q-ml-sm" />
        </div>

      </q-form>
    </q-card>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue'
import { Notify } from 'quasar'
import axios from 'axios'
import { BASE_URL } from '../api.config'

export default defineComponent({
  name: 'AddAuthor',

  data () {
    return {
      firstName: ref(''),
      lastName: ref(''),
      email: ref(''),
      phone: ref('')
    }
  },

  computed: {
    firstNameRules () {
      return [
        (v) => !!v || 'First Name is required.',
        (v) => (v && v.length <= 50) || 'First Name should be less than 50 characters.'
      ]
    },
    lastNameRules () {
      return [
        (v) => !!v || 'Last Name is required.',
        (v) => !v || v.length <= 50 || 'Last Name should be less than 50 characters.'
      ]
    },
    isFirstNameValid () {
      return this.firstName && this.firstName.length <= 50
    },
    isLastNameValid () {
      return !this.lastName || this.lastName.length <= 50
    },
    hasActiveErrors () {
      return !this.isFirstNameValid || !this.isLastNameValid
    }
  },

  methods: {
    async addAuthor () {
      try {
        const response = await axios.post(`${BASE_URL}/authors/create`, {
          firstName: this.firstName,
          lastName: this.lastName,
          email: this.email,
          phone: this.phone
        })

        this.showSucceedMessage('Author added successfully!')

        this.$router.push({ name: 'home' })
      } catch (error) {
        if (error.response.data) { this.showErrorMessage(error, 'Error adding author: ') }
      }
    },

    showErrorMessage (error: any, message: string): void {
      Notify.create({
        message: `${message} ${error.response.data}`,
        color: 'negative',
        icon: 'warning'
      })
    },

    showSucceedMessage (message: string): void {
      Notify.create({
        message: `${message}`,
        color: 'positive',
        icon: 'check'
      })
    }
  }
})
</script>

<style>
.form-group {
  margin-bottom: 10px;
}
</style>
